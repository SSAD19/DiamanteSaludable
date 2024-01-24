using System.Data;
using System.Data.Common;
using System.Security.AccessControl;
using System.Transactions;
using Microsoft.Data.SqlClient;

namespace AccesoDatos
{
    public class AccesoDB: IDisposable
        {
        private string conexString = @"Data Source=;Initial Catalog=; Integrated Security=true;Encrypt=False;";
        SqlConnection miConex = new SqlConnection();
        public void Dispose()
        {
            try
            {
                
                if (miConex.State != ConnectionState.Closed)
                {
                    miConex.Close();
                }


            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: ${e.Message}, ${e.StackTrace}.");
            }

            miConex.Dispose();
        }

     // selects para vistas y entidades
        public DataTable TraerDataT(string _query)
        {
            var miTabla = new DataTable();
            var miData = new DataSet();

            try
            {
                using (miConex = new SqlConnection(conexString))
                {
                    SqlCommand comando = new SqlCommand(_query, miConex);
                    miConex.Open();
                    //probar colocando miConex.Open().BeginTRansaction()

                    var miAdaptador = new SqlDataAdapter(comando);
                    miAdaptador.Fill(miTabla);
                }

            }
            catch (Exception e)
            {

                Console.WriteLine($"Error: {e.Message} - {e.StackTrace}");
            }

            return miTabla;
        }

        public void HacerTransaccion(string _query)
        {
            try
            {
                using (miConex = new SqlConnection(conexString))
                {
                    SqlCommand comando = new SqlCommand(_query, miConex);
                    miConex.Open();
                    comando.ExecuteNonQuery();

                }

                Console.WriteLine("Operación exitosa");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al iniciar la transacción: {e.Message}");
            }
        }


        public void ObtenerUno (string _query, object _xEntidad)
        {
             try
            {
                using (SqlConnection miConex = new SqlConnection(conexString))
                {
                    SqlCommand comando = new SqlCommand(_query, miConex);
                    miConex.Open();

                    _xEntidad = comando.ExecuteScalar(); 

                }
            }
            catch (Exception e) {

                Console.WriteLine($"Error: {e.Message}, ruta: {e.StackTrace}");
            }

        }

    }
}
