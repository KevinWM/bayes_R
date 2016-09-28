
create table clasificacion(

	id			serial not null,
	nombre			varchar(30) not null,

	CONSTRAINT clasificacion_key PRIMARY KEY (id)
);

create table documento(

	id			serial not null,
	nombre			varchar(30) not null,
	id_Clasificacion	integer,

	CONSTRAINT documento_key PRIMARY KEY (id),
	CONSTRAINT clasificacion_documento FOREIGN KEY 
	(id_Clasificacion) REFERENCES clasificacion(id)
);

create table palabra(

	id 			serial not null,
	nombre			varchar(50) not null,
	num_Repeticiones	integer not null,
	id_Documento		integer not null,

	CONSTRAINT palabra_key PRIMARY KEY (id),
	CONSTRAINT documento_palabra FOREIGN KEY (id_Documento)
	REFERENCES documento(id)
);

create table documentoActual(

	id			serial not null,
	nombre			varchar(30) not null,
	id_Clasificacion	integer	

);

create table palabraActual(

	id 			serial not null,
	nombre			varchar(50) not null,
	num_Repeticiones	integer not null,
	id_Documento		integer not null		

);

create table palabraTemporal(

	id 				serial not null,
	nombre				varchar(50) not null,
	num_Repeticiones		integer not null,
	id_clasificacionTemporal	integer not null
);

create table clasificacionTemporal(

	id			serial not null,
	nombre			varchar(30) not null,
	cant_Documentos		integer
);


create table usuarioTwitter(

	id			serial not null,
	nombre			varchar(30) not null

);
create table usuario(

	id			serial not null,
	usuario			varchar(30) not null
);
create table tweets(

	id			serial not null,
	tweet			varchar(140) not null,
	idUsario		varchar(30) not null
);


SELECT nombre, count(num_repeticiones) as num_repeticiones
FROM palabratemporal 
inner join clasificaciontemporal on clasificaciontemporal.id = palabratemporal.id_clasificaciontemporal
and clasificaciontemporal.nombre = 'Deportes'
GROUP BY nombre
ORDER BY num_repeticiones desc

SELECT palabras.nombre, count(num_repeticiones) as num_repeticiones
FROM
(select palabratemporal.nombre, palabratemporal.num_repeticiones from palabratemporal 
inner join clasificaciontemporal on clasificaciontemporal.id = palabratemporal.id_clasificaciontemporal
and clasificaciontemporal.nombre = 'Deportes') as palabras
GROUP BY nombre
ORDER BY num_repeticiones desc

select * from palabratemporal



select * from tweets
select * from documento
select * from palabra
select * from clasificacion