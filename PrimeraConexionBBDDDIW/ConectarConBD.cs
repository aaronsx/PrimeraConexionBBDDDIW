using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraConexionBBDDDIW.Conexion
{

    internal class ConectarConBD
    {
        NpgsqlConnection coneBD = new NpgsqlConnection();

        static string json = File.ReadAllText("variableEntorno.json");
        static JObject jsonObj = JObject.Parse(json);

        static String servidor = (string)jsonObj.SelectToken("Bd.servidor");
        static String bd = (string)jsonObj.SelectToken("Bd.bd");
        static String usu = (string)jsonObj.SelectToken("Bd.usu");
        static String pass = (string)jsonObj.SelectToken("Bd.pass");


        static String cadena = $"Server={servidor};User Id={usu}; Password={pass};Database={bd};";


        public NpgsqlConnection ConexionEstablecida()
        {
            try
            {
                coneBD.ConnectionString = cadena;
                coneBD.Open();

            }
            catch (NpgsqlException e)
            {
                Console.Error.WriteLine(e.Message);
            }
            return coneBD;
        }
        public void HacerConsulta()
        {
            String query = "select * from gbp_almacen.gbp_alm_cat_libros;";
            NpgsqlCommand command = new NpgsqlCommand(query, coneBD);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", reader[0], reader[1], reader[2], reader[3], reader[4]);
            }
            Console.ReadKey();
        }
       public void ConexionCerrar()
        {
            coneBD.Close();
        }
    }
}
