using System.Data;
using Microsoft.Data.SqlClient;



namespace AccesoDatos
{
    public class AccesoBase
    {
        SqlConnection miConex;
        SqlCommand miComando;
        SqlTransaction miTransaccion;


        public SqlConnection AbrirConex(string conexString)
        {
            try
            {

                using (miConex = new SqlConnection(conexString))
                {
                    if (miConex.State != ConnectionState.Open)
                    {
                        miConex.Open();
                        Console.WriteLine("si conectó");
                    }
                }

            }

            catch (Exception e)
            {
                // Manejo de excepciones, por ejemplo, puedes registrar el error
                Console.WriteLine($"Error al abrir la conexión: {e.Message}");
               
            }

            return miConex;
        }

        //Ejecutar Query puntual
        public void Query(string _comando, string _conexString)
        {
            miComando = new SqlCommand(_comando);
            try
            {
                using (var miConex = new SqlConnection(_conexString))
                {
                    miComando.ExecuteNonQuery();
                }
            }
            catch
            {
                Console.WriteLine("No se pudo realizar la consulta,  problema con la query ingresada.");
            }

            //quiero usar query 

        }


        
        //Revisar documentacion y como Rodri usa transacciones
        public IDbTransaction Transaccion(string _conexString)
        {

            try
            {
                using (var conexion = AbrirConex(_conexString))
                {
                    IDbTransaction miTransaccion = conexion.BeginTransaction();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error al iniciar la transacción:${e.Message}");
            }
            return miTransaccion;
        }


       
        public void Dispose(string _conexString)
        {
            try
            {

                using (var conexion = AbrirConex(_conexString)) { 
                    if (miConex.State != ConnectionState.Closed)
                    {
                        miConex.Close();
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: ${e.Message}, ${e.StackTrace}.");
            }

            miConex.Dispose();

        }
    }

}
