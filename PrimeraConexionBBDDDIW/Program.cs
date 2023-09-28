using Npgsql;
using PrimeraConexionBBDDDIW.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraConexionBBDDDIW
{
    internal class Program
    {
        /// <summary>
        /// Metodo para main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ConectarConBD con =new ConectarConBD();
            NpgsqlConnection coneBD = null;
            coneBD = con.ConexionEstablecida();
            con.HacerConsulta();
            con.ConexionCerrar();
        }
    }
}
