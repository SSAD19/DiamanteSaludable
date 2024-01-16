using System.Data;
using System.Data.Common;
using System.Transactions;
using Microsoft.Data.SqlClient;



namespace AccesoDatos
{
    public class AccesoBase : IDisposable
    {
        SqlConnection miConex;
        SqlCommand miComando;
        SqlTransaction miTransaccion;

        private string conexString = @"Data Source=DESKTOP-P0J7R4I\SQLEXPRESS;Initial Catalog=Diamante; Integrated Security=true;Encrypt=False;";

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

        private void AbrirConexion()
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
        }

        public void IniciarTransaccion()
        {
            try
            {
                AbrirConexion();
                miTransaccion = miConex.BeginTransaction();
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
            Dispose();
        }
         
        public DataTable TraerDataT(string _comando)
        {
            var miData = new DataSet();
            var miTabla = new DataTable();
            var miAdaptador = new SqlDataAdapter();
            var _conex = new AccesoBase();

            try
            {
                IniciarTransaccion();
               //TODO: Revisar error acá, no conecta
                miComando.CommandText = _comando;
                miAdaptador.SelectCommand = miComando;
                miAdaptador.Fill(miData);
                miTabla = miData.Tables.Count > 0 ? miData.Tables[0] : new DataTable();
               

                CerrarTransaccion();
            }
            catch (Exception e)
            {
                miTransaccion?.Rollback();
                Console.WriteLine($"Error: {e.Message} - {e.StackTrace}");
            }

            return miTabla;
        }

        public void HacerTransaccion(string _comando)
        {
            try
            {
                IniciarTransaccion();
                using (SqlCommand comando = miConex.CreateCommand())
                {
                    comando.CommandText = _comando;
                    comando.ExecuteNonQuery();
                }

                CerrarTransaccion();
                Console.WriteLine("Operación exitosa");
            }
            catch (Exception e)
            {
                miTransaccion?.Rollback();
                Console.WriteLine($"Error al iniciar la transacción: {e.Message}");
            }
            finally
            {
                Dispose();
            }
        }
    }
}

