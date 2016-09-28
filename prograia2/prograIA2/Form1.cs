using NTextCat;
using Npgsql;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RDotNet;


namespace prograIA2
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
            cargarComboboxCategoria();        
        }

        int cantCorreos;
        int cantTweets;

        List<string> mensajes = new List<string>();
        List<string> tweets = new List<string>();

        private void descargarCorreos(object sender, EventArgs e)
        {
            if (correoText.Text != "" && contrasenaText.Text != "")
            {
                using (Pop3Client client = new Pop3Client())
                {
                    client.Connect("pop.gmail.com", 995, true);
                    client.Authenticate(correoText.Text, contrasenaText.Text, AuthenticationMethod.UsernameAndPassword);
                    int messageCount = client.GetMessageCount();
                    cantCorreos = messageCount;
                    List<OpenPop.Mime.Message> allMessages = new List<OpenPop.Mime.Message>(messageCount);
                    for (int d = messageCount; d > 0; d--)
                    {
                        if (!client.GetMessage(d).MessagePart.MessageParts[0].IsMultiPart)
                        {
                            //allMessages.Add(client.GetMessage(d));
                            //Console.WriteLine(client.GetMessage(d).Headers.Subject);
                            mensajes.Add(client.GetMessage(d).MessagePart.MessageParts[0].GetBodyAsText());
                        }
                    }

                    //for (int d = allMessages.Count-1; d > 0; d--)
                    //{
                    //    Console.WriteLine(allMessages[d].MessagePart.MessageParts[0].GetBodyAsText());
                    //    Console.WriteLine("---------------------------------------------------------");
                    //}
                }
                guardarCorreos(mensajes);
            }
        }

        

        private string identificarIdioma(string texto)
        {
            var factory = new RankedLanguageIdentifierFactory();//C:\Users\Jonathan\Desktop\proyectoIA\proyectoIA\prograIA2\prograIA2\prograIA2
            var identifier = factory.Load("D:/Todo/Escritorio/HP/proyectoIA/prograia2/prograia2/prograIA2/Core14.profile.xml");
            var languages = identifier.Identify(texto);
            var mostCertainLanguage = languages.FirstOrDefault();
            if (mostCertainLanguage != null)
                return mostCertainLanguage.Item1.Iso639_3;
            return "asd";
            
        }

        private string[] dividirTexto(string texto) 
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '[', ']', '(', ')', '!', '¡', '*', '¿', '?', '>', '<', '\t', '\r', '\n', '/', '"', '‘', '“', '”', '.', '\'' };

            string[] words = texto.Split(delimiterChars);

            //foreach (string s in words)
            //{
            //    System.Console.WriteLine(s);
            //}
            return words;
        }

        private void guardarCorreos(List<string> texto)
        {
            for (int i = 0; i < texto.Count; i++)
            {
                if (identificarIdioma(texto[i]) == "spa")
                {
                    List<string> palabras = new List<string>();
                    string[] words = dividirTexto(texto[i]);
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine(texto[i]);
                    guardarPalabras(words, i+1);
                    //Console.WriteLine(mensajes[i]);}
                }
            }
        }
        
        private void guardarPalabras(string[] words, int canDocs)
        {
            List<string> textoLimpio = new List<string>();
            List<string> palabraUnicas = new List<string>();
            //List<int> cantVeces = new List<int>();
            int cantRep = 0;

           

            NpgsqlConnection conection = new NpgsqlConnection();
            conection.ConnectionString = "Server=localhost;Port=5432;Database=prograIA;User Id=postgres;Password=12345";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conection;

            string nombre = "Docu_" + canDocs;

            cmd.CommandText = "insert into documentoActual (nombre) values (@nombre) returning id";
            cmd.Parameters.Add(new NpgsqlParameter("nombre", DbType.String));
            cmd.Parameters[0].Value = nombre;
            conection.Open();
            Object id = cmd.ExecuteScalar();
            int id_Documento = int.Parse(id.ToString());
            conection.Close();

            foreach (string s in words)
            {
                if (s.Length > 3 && s.Length < 30)
                {
                    textoLimpio.Add(s);
                }
            }

            for (int i = 0; i < textoLimpio.Count; i++)
            {
                palabraUnicas.Add(textoLimpio[i]);
                //cantVeces.Add(1);
                for (int b = i; b < textoLimpio.Count-1; b++)
                {
                    if(textoLimpio[i] == textoLimpio[b])
                    {
                        //cantVeces[i]++;
                        cantRep++;
                        textoLimpio.RemoveAt(b);
                    }
                }
               
                NpgsqlCommand asd = new NpgsqlCommand();
                asd.Connection = conection;
                asd.CommandText  = "Insert into palabraActual (nombre, num_Repeticiones, id_documento)"+
                "values(@nombre, @num_repe, @id_docu)";
                asd.Parameters.Add(new NpgsqlParameter("nombre", DbType.String));
                asd.Parameters.Add(new NpgsqlParameter("num_repe", DbType.VarNumeric));
                asd.Parameters.Add(new NpgsqlParameter("id_docu", DbType.VarNumeric));
                
                asd.Parameters[0].Value = palabraUnicas[i];
                asd.Parameters[1].Value = cantRep;
                asd.Parameters[2].Value = id_Documento;
                conection.Open();
                asd.ExecuteScalar();
                conection.Close();
                cantRep = 0;
            }
        }

        private void agregarClasificacion(object sender, EventArgs e)
        {   
            if(nombreClasiText.Text != null){
                NpgsqlConnection conection = new NpgsqlConnection();
                conection.ConnectionString = "Server=localhost;Port=5432;Database=prograIA;User Id=postgres;Password=12345";
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conection;

                cmd.CommandText = "insert into clasificacion (nombre) values (@nombre)";
                cmd.Parameters.Add(new NpgsqlParameter("nombre", DbType.String));
                cmd.Parameters[0].Value = nombreClasiText.Text;
                conection.Open();
                cmd.ExecuteScalar();
                conection.Close();

                cargarComboboxCategoria();
            }
        }

        
        private void agregarTextoDocumento(object sender, EventArgs e)
        {
            List<string> palabraUnicas = new List<string>();

            if ((nombreDocumenTextBox.Text != null) && (richTextBox1.Text != ""))
            {
                NpgsqlConnection conection = new NpgsqlConnection();
                conection.ConnectionString = "Server=localhost;Port=5432;Database=prograIA;User Id=postgres;Password=12345";
         
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = conection;
                command.CommandText = "select id from clasificacion where clasificacion.nombre = @nombre";
                command.Parameters.Add(new NpgsqlParameter("nombre", DbType.String));
                command.Parameters[0].Value = clasificarDocuComboBox.Text;
                conection.Open();
                NpgsqlDataReader dr = command.ExecuteReader();

                dr.Read();
                int id = int.Parse(dr[0].ToString());
                conection.Close();

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conection;
                conection.Open();
                cmd.CommandText = "insert into documento (nombre, id_clasificacion) values (@nombre, @id_clasificacion) returning id";
                cmd.Parameters.Add(new NpgsqlParameter("nombre", DbType.String));
                cmd.Parameters.Add(new NpgsqlParameter("id_clasificacion", DbType.VarNumeric));
                cmd.Parameters[0].Value = nombreDocumenTextBox.Text;
                cmd.Parameters[1].Value = id;
                Object id_Docu = cmd.ExecuteScalar();
                int idDocumento = int.Parse(id_Docu.ToString());
                conection.Close();

                string texto = richTextBox1.Text;
                Console.WriteLine(texto);

                List<string> textoLimpio = new List<string>();
                string[] words = dividirTexto(texto);
                int cantRep = 0;

                foreach (string s in words)
                {
                    if (s.Length > 3 && s.Length <= 30)
                    {
                        textoLimpio.Add(s);
                    }
                }
                int i = 0;
                while (textoLimpio.Count() > 0)
                {
                    palabraUnicas.Add(textoLimpio[0]);
                    //cantVeces.Add(1);
                    for (int b = 0; b < textoLimpio.Count; b++)
                    {
                        if (palabraUnicas[i] == textoLimpio[b])
                        {
                            //cantVeces[i]++;
                            cantRep++;
                            textoLimpio.RemoveAt(b);
                            b = 0;
                        }
                    }
                    
                    NpgsqlCommand query = new NpgsqlCommand();
                    query.Connection = conection;
                    query.CommandText = "Insert into palabra(nombre, num_Repeticiones, id_documento)" +
                    "values(@nombre, @num_repe, @id_docu)";
                    query.Parameters.Add(new NpgsqlParameter("nombre", DbType.String));
                    query.Parameters.Add(new NpgsqlParameter("num_repe", DbType.VarNumeric));
                    query.Parameters.Add(new NpgsqlParameter("id_docu", DbType.VarNumeric));
                    Console.WriteLine(palabraUnicas[i]);
                    query.Parameters[0].Value = palabraUnicas[i];
                    query.Parameters[1].Value = cantRep;
                    query.Parameters[2].Value = idDocumento;
                    conection.Open();
                    query.ExecuteScalar();
                    conection.Close();
                    cantRep = 0;
                    i++;
                }
                nombreDocumenTextBox.Text = "";
                richTextBox1.Text = "";
            }
        }

        public void cargarComboboxCategoria()
        {
            clasificarDocuComboBox.Items.Clear();

            NpgsqlConnection conection = new NpgsqlConnection();
            conection.ConnectionString = "Server=localhost;Port=5432;Database=prograIA;User Id=postgres;Password=12345";
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conection;

            cmd.CommandText = "select nombre from clasificacion";
            conection.Open();
            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                clasificarDocuComboBox.Items.Add(dr[0]);
            }

            conection.Close();
        }

        private void analizarTweets(object sender, EventArgs e)
        {
            NpgsqlConnection conection = new NpgsqlConnection();
            conection.ConnectionString = "Server=localhost;Port=5432;Database=prograIA;User Id=postgres;Password=12345";

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conection;
            command.CommandText = "SELECT tweet from tweets where idusario = @nombre";
            command.Parameters.Add(new NpgsqlParameter("nombre", DbType.String));
            command.Parameters[0].Value = usuarioTwitterText.Text;
            conection.Open();
            NpgsqlDataReader dr = command.ExecuteReader();

            dr.Read();

            while (dr.Read())
            {
                tweets.Add(dr[0].ToString());
            }

            conection.Close();

            guardarCorreos(tweets);
            
        }

        private void analizarCorreos(object sender, EventArgs e)
        {
            REngine.SetEnvironmentVariables();
            using (REngine engine = REngine.GetInstance())
            {
                engine.Initialize();
                engine.Evaluate("source('D:/Todo/Escritorio/HP/proyectoIA/bayes.r')");
            }
        }

        private void ejecutarScriptR(object sender, EventArgs e)
        {
            NpgsqlConnection conection = new NpgsqlConnection();
            conection.ConnectionString = "Server=localhost;Port=5432;Database=prograIA;User Id=postgres;Password=12345";
            conection.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conection;
            command.CommandText = "Insert into usuarioTwitter(nombre) values (@nombre)";
            command.Parameters.Add(new NpgsqlParameter("nombre", DbType.String));
            command.Parameters[0].Value = usuarioTwitterText.Text;
            
            command.ExecuteScalar();
            conection.Close();

            REngine.SetEnvironmentVariables();
            using (REngine engine = REngine.GetInstance())
            {
                engine.Initialize();
                engine.Evaluate("source('D:/Todo/Escritorio/HP/proyectoIA/twiterR.r')");
            }
        }
    }
}
