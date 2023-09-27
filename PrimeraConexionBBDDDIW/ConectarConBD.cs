using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraConexionBBDDDIW.Conexion
{
    internal class ConectarConBD
    {
        NpgsqlConnection coneBD= new NpgsqlConnection();
        static String servidor= "localhost:5432";
        static String bd= "gestorBibliotecaPersonal";
        static String usu= "postgres";
        static String pass= "aaronsenen001!";
      

        String cadena =String.Format("Server={0};User Id={1}; Password={2};Database={3};", servidor,usu, pass, bd);
        
        public NpgsqlConnection ConexionEstablecida() 
        {
            try 
            {
                coneBD.ConnectionString = cadena;
                coneBD.Open();

            }catch(NpgsqlException e) 
            {
                Console.Error.WriteLine(e.Message);
            }
            return coneBD;
        }
        public void HacerConsulta()
        {
            String query = "select * from gbp_almacen.gbp_alm_cat_libros;";
            NpgsqlCommand command=new NpgsqlCommand(query, coneBD);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) 
            {
                Console.WriteLine("{0} {1} {2} {3} {4}",reader[0], reader[1], reader[2], reader[3], reader[4]);
            }
            Console.ReadKey();
        }
    }
}
