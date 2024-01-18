using System.Data;
using System.Data.Common;
using System.Transactions;
using Microsoft.Data.SqlClient;



namespace AccesoDatos
{
    public class AccesoDB: IDisposable
        {
        private string conexString = @"Data Source=DESKTOP-P0J7R4I\SQLEXPRESS;Initial Catalog=Diamante; Integrated Security=true;Encrypt=False;";
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

        /*
         * 
          SqlConnection miConex;
          SqlTransaction miTransaccion;
          SqlCommand miComando; 

          private SqlConnection AbrirConexion()
          {
              try
              {
                  miConex = new SqlConnection(conexString);

                  if (miConex.State != ConnectionState.Open)
                  {
                      miConex.Open();
                      Console.WriteLine("Conexión exitosa");
                  }
              }
              catch (Exception e)
              {
                  Console.WriteLine($"Error al abrir la conexión: {e.Message}");
              }

              return miConex;
          }

          public void IniciarTransaccion()
          {
              try
              {
                  miTransaccion = AbrirConexion().BeginTransaction();
              }
              catch (Exception e)
              {
                  miTransaccion?.Rollback();
                  Console.WriteLine($"Error al iniciar la transacción: {e.Message}");
              }
          }

          public void CerrarTransaccion()
          {
              miTransaccion?.Commit();
          }
        */

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




    }
}
