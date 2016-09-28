#
#       El objetivo de este escript es el de asignarle a una clasificacion a un texto usando 
#       el algoritmo de bayes
#       Se hacen consultas a la base de datos para obtener las palabras del texto para realizar su  
#       respectivo analisis
#

library(RPostgreSQL)

con=dbConnect(PostgreSQL(), user="postgres", password="12345", dbname="prograIA")

#usa la varianza y media para calcular la probabilidad
calcularProb <- function(palabrasEntrenamiendo, palabrasActual, probCategoria, categoria, listaProbabilidades, id)
{
  palaEn <- palabrasEntrenamiendo
  palaAc <- palabrasActual
  
  consulta = paste(paste("update clasificaciontemporal set cant_documentos = (cant_documentos + 1) where clasificaciontemporal.nombre = '", 
                   paste(categoria, "'", sep=""), sep = ""), " returning id", sep = "")
  idModiClasiCat = dbGetQuery(con, consulta)

  totalProbabilidadCategoria<-probCategoria
  
  i <- 1
  while (i <= length(palaAc[,1]))
  {
    b <- 1
    while (b <= length(palaEn[,1]))
    {
      if(palaAc[i,"nombre"] == palaEn[b,"nombre"])
      {
        palabra <- palaAc[i,"nombre"]
        
        todasPalbrasCategoria <- paste("select palabra.num_repeticiones from clasificacion
                          	        inner join documento on documento.id_clasificacion = clasificacion.id
                                    inner join palabra on palabra.id_documento = documento.id
                                    and palabra.nombre = '", paste(palabra, "'", sep=""), sep = "")
        
        todasPalbrasCategoria1 <- paste0("and clasificacion.nombre = '",paste(categoria, "'", sep=""), sep = "")
        palabras <- paste(todasPalbrasCategoria, todasPalbrasCategoria1)
        palabrasDocumentos = dbGetQuery(con, palabras)
        
        media <- apply(palabrasDocumentos,2,median)
        varianza <- apply(palabrasDocumentos,2,var)
        
        if(is.na(varianza))
        {
          varianza <- media
        }
        if(varianza == 0)
        {
          varianza <- 0.01
        }
        cantPalabra <- palaAc[i,"num_repeticiones"]
        
        probAux <- dnorm(cantPalabra, mean=media, sd=varianza)
        
        totalProbabilidadCategoria <- totalProbabilidadCategoria * probAux
      }
      b<-b+1
      
      #guardar palabras para aprender
      
    }
    bandera<-1
    i<-i+1
  }
  listaProbabilidades<-rbind(listaProbabilidades, c(categoria,totalProbabilidadCategoria, id, 0))
  return(listaProbabilidades)
}

#une las palabras de entrenamiento
palabrasPorCategoria <- function(categoria, palabrasActual, probCategoria, listaProbabilidades, id)
{
  todasPalbrasCategoria = paste("select palabra.nombre, palabra.num_repeticiones from palabra inner join documento on palabra.id_documento = documento.id
                        inner join clasificacion on clasificacion.id = documento.id_clasificacion
                           and clasificacion.nombre = '", paste(categoria, "'", sep=""), sep = "")
  
  data = dbGetQuery(con, todasPalbrasCategoria)
  
  cantDocumentos <- 1
  cantRepeticiones <- 1
  i<-1
  matrizFinal<-matrix(nrow=0, ncol=3)
  colnames(matrizFinal)<-c("nombre","num_repeticiones","cantDocumentos")
  
  while (i < length(data[,1]))
  {
    b<-i+1
    cantRepeticiones<-data[i,"num_repeticiones"]
    while (b <= length(data[,1]))
    {
      if(data[i,"nombre"] == data[b,"nombre"])
      {
        cantRepeticiones<-data[b,"num_repeticiones"] + cantRepeticiones
        data<- data[-b,]
        cantDocumentos<-cantDocumentos+1
      }
      b<-b+1
    }
    matrizFinal<-rbind(matrizFinal, c(data[i,"nombre"],cantRepeticiones,cantDocumentos))
    cantDocumentos <- 1
    cantRepeticiones <- 1
    i<-i+1
  }
  
  #llamar un metodo que reciba las palabras de entrenamiento y las actuales para calcular las probabilidades
  asd1 <- calcularProb(matrizFinal, palabrasActual, probCategoria, categoria, listaProbabilidades, id)
  return(asd1)
  
}

#Obtiene las palabras del texto que se desea clasificar

obtenerPalabrasActuales<- function()
{
  listaProbabilidades<-matrix(ncol=4)
  colnames(listaProbabilidades)<-c("clasificacion","probabilidad","idDocumento", "probTotal")
  listaProbabilidades<- listaProbabilidades[-1,]
  
  consulta = ("select documentoactual.id from documentoactual
                           where documentoactual.id_clasificacion is null")
  documentosActuales = dbGetQuery(con, consulta)
  
  consulta1 = ("select clasificacion.nombre from clasificacion")
  clasificacion = dbGetQuery(con, consulta1)
  
  i <- length(documentosActuales[,1])
  b <- 1
  a <- length(clasificacion[,1])
  
  while (b <= i)
  {
    id <- documentosActuales[b,"id"]
    
    consulta2 = paste("select * from palabraactual where palabraactual.id_documento = ", id)
    palabrasActuales = dbGetQuery(con, consulta2)
    
    d <- 1
    #consultar todas la categorias, while que recorra las categorias
    while (d <= a)
    {
      consulta3 = ("select count(*) from documento")
      cantDocumentos = dbGetQuery(con, consulta3)
      
      consulta4 = paste("select count(*) from documento 
                   inner join clasificacion on clasificacion.id = documento.id_clasificacion 
                   and clasificacion.nombre = '", paste(clasificacion[d,], "'", sep = ""), sep = "")
      cantDocumuentosCategoria = dbGetQuery(con, consulta4)
      
      probCategoria <- cantDocumuentosCategoria/cantDocumentos
      nombreCategoria<-clasificacion[d,"nombre"]
      
      
      #Envia las palabras de entrenamiento de una categoria especifica junto a las palabras del texto que se quiere
      #analizar
      
      listaFinal <- palabrasPorCategoria(nombreCategoria, palabrasActuales, probCategoria, listaProbabilidades, id)
      
      listaProbabilidades <- listaFinal
      d <- d + 1
    }
    #evaluar y limpiar listaProbabilidades  1.312671739x10 24        
    
    
    b <- 1 + b
  }
  
  return(listaProbabilidades)
  
  
}

#crea una matriz con las probabilidades obtenidas para cada categoria de un documento

clasificar<- function()
{
  
  #continua el flujo
  listaProbabilidades <- obtenerPalabrasActuales()
  
  consulta = ("select count(*) from clasificacion")
  cantClasificaciones <- dbGetQuery(con, consulta)
  
  divisor <- 0
  tamano = length(listaProbabilidades[,1])
  i <- 1 
  qwe <- cantClasificaciones
  while (i <= tamano)
  {
    a <- i
    while (a <= qwe)
    {
      b <- i
      while (b <= qwe)
      {
        divisor <- divisor + as.numeric(listaProbabilidades[as.numeric(b),"probabilidad"] )
        b <- b + 1
      }
      listaProbabilidades[as.numeric(a),"probTotal"] <- as.numeric(listaProbabilidades[as.numeric(a),"probabilidad"]) / divisor
      divisor <- 0
      a <- a + 1
    }
    i <- i + cantClasificaciones
    qwe <- qwe + qwe
  }
  
  return(listaProbabilidades)
  
}

#asigna la categoria del documento analizando las distintas probabilidades de cada documento respecto
#a la probailidad que tenga con cada categoria

guardarCategoria<- function()
{
  #continua la secuencia para obtener la clasificacion
  listaProbabilidades <- clasificar()
  
  
  consulta = ("select count(*) from clasificacion")
  cantClasificaciones <- dbGetQuery(con, consulta)
  
  menor <- 1e+999
  guardarCategoria <- 0
  menorID <- 0
  menorClase <- "a"
  tamano = length(listaProbabilidades[,1])
  i <- 1 
  qwe <- cantClasificaciones
  nombreClasificacion<-""
  
  while (i <= tamano)
  {
    a <- i
    while (a <= qwe)
    {
      
        if(as.numeric(listaProbabilidades[as.numeric(a),"probTotal"]) < menor)
        {
          menorProb <- listaProbabilidades[as.numeric(a),"probTotal"]
          menorID <- listaProbabilidades[as.numeric(a),"idDocumento"]
          menorClase <- listaProbabilidades[as.numeric(a),"probabilidad"]
          menor <- listaProbabilidades[as.numeric(a),"probTotal"]
          nombreClasificacion <- listaProbabilidades[as.numeric(a), "clasificacion"]
        }
      a <- a + 1
    }
    i <- i + cantClasificaciones
    qwe <- qwe + qwe
    menor <- 1e+999
    
    
    #inserta  insert into documentoactual (id_clasificacion) values ()
    query = paste("select id from clasificacion where clasificacion.nombre = '", 
                      paste(nombreClasificacion, "'", sep=""), sep="")
    conIdClas <- dbGetQuery(con, query)
    
    queryAux = paste(paste(paste("update documentoactual set id_clasificacion = ", conIdClas[1, "id"], sep = "")
                     , " where documentoactual.id = "), menorID, sep = )
    
    consultaModificacion = dbGetQuery(con, queryAux)
    
    query1 = paste(paste("select distinct palabraactual.nombre, palabraactual.num_repeticiones, palabraactual.id_documento from palabraactual inner join documentoactual on documentoactual.id = palabraactual.id_documento and documentoactual.id = ", menorID, sep = " "),
                   "inner join documento on documento.id_clasificacion = documentoactual.id_clasificacion inner join palabra on palabra.id_documento = documento.id and palabraactual.nombre != palabra.nombre", sep = "")
    obtenerPalabrasTemporales = dbGetQuery(con, query1)
    
    x = 1
    while(x <= length(obtenerPalabrasTemporales)){
      consulta1 = paste(
        paste(
          paste(
            paste(
              paste(
                paste("Insert into palabratemporal (nombre, num_repeticiones, id_clasificaciontemporal) values ('",
                      obtenerPalabrasTemporales[x, "nombre"], sep = ""), "' ,",sep = ""),
              obtenerPalabrasTemporales[x, "num_repeticiones"], sep = ""),
            " ,", sep = ""),
          conIdClas[1, "id"], sep = ""),
        ")", sep = "")
      
      agregarPalabraTemp = dbGetQuery(con, consulta1)
      x = x + 1
    }
    
  }
}


#metodo inicial
iniciarBayes <- guardarCategoria()




