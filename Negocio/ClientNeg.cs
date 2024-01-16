using AccesoDatos;
using Entidades;
using Microsoft.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Negocio
{
    public class ClientNeg
    {
        public List<Clientes> misClientes = new List<Clientes>();
        private AccesoBase traer = new AccesoBase();

        //traer clientes  todos 
        public List<Clientes> RecuperarClientes(string _conexString)
        {

            string _comando = "SELECT * FROM clientes WHERE Baja='false';";

            try
            {
                using (var conex = new SqlConnection())
                {
                    traer = new AccesoBase();
                    var dataT = new DataTable();
                    dataT = traer.TraerDataT(_comando);
                    
                    var cliente = new Clientes();

                    foreach (DataRow fila in dataT.Rows)
                    {
                        cliente = new Clientes();

                        cliente.Codigo = int.Parse(fila[0].ToString()!);
                        cliente.Nombre = fila[1].ToString() ?? "sin data";
                        cliente.Apellido = fila[2].ToString() ?? "sin data";
                        cliente.Wapp = fila[3].ToString()!; 
                        cliente.Calle = fila[4].ToString() ?? "sin data";
                        cliente.Numero = fila[5].ToString() ?? "sin data";
                        cliente.Localidad = fila[8].ToString() ?? "sin data";
                        cliente.Observacion = fila[9].ToString() ?? "sin data";
                        cliente.Correo = fila[14].ToString() ?? "sin data";

                        misClientes.Add(cliente);
                    }

                }

            }
            catch (Exception e)
            {

                Console.WriteLine($"Error: {e.Message} - {e.StackTrace}");
            }

            return misClientes;

        }

        //traer cliente puntual - revisar DB  colocar el dato de wapp como unique 
        public Clientes RecuperarUNO(string _conexString, string _wapp)
        {
            string _comando = $"SELECT * FROM clientes WHERE Wapp LIKE '%{_wapp}%';";
            
            var cliente = new Clientes();


           try
            {

                using (var conex = new SqlConnection())
                {
                    traer = new AccesoBase();
                    var dataT = new DataTable();
                    dataT = traer.TraerDataT(_comando);

                    cliente.Codigo = int.Parse(dataT.Rows[0].ToString()!);
                    cliente.Nombre = dataT.Rows[1].ToString() ?? "sin data";
                    cliente.Apellido = dataT.Rows[2].ToString() ?? "sin data";
                    cliente.Wapp = dataT.Rows[3].ToString()!;
                    cliente.Calle = dataT.Rows[4].ToString() ?? "sin data"; 
                    cliente.Numero = dataT.Rows[5].ToString() ?? "sin data"; 
                    cliente.Localidad = dataT.Rows[8].ToString() ?? "sin data"; ;
                    cliente.Observacion = dataT.Rows[9].ToString() ?? "sin data";
                    cliente.Correo = dataT.Rows[14].ToString() ?? "sin data";
                }
            }

            catch (Exception e)
            {

                Console.WriteLine($"Error: {e.Message} - {e.StackTrace}");
            }
            return cliente;

        }

        public void AltaCliente (Clientes _cliente)
        {
            string comando = @"INSERT INTO Clientes (Nombre, Apellido, Wapp, Calle, Numero, Localidad, Observación, Correo)
                VALUES
            ('"+_cliente.Nombre+"','"+_cliente.Apellido+ "', '"+_cliente.Wapp+"','"+ _cliente.Calle+"', '" + _cliente.Numero + "', '" + _cliente.Localidad + "', '"+_cliente.Observacion+"', '"+_cliente.Correo+"', 'false')";

            using (var conex = new SqlConnection()) {

                traer.HacerTransaccion(comando); 

            }

        }


        public void ModificarCliente(Clientes _cliente)
        {
            string comando = @"UPDATE INTO Clientes (Nombre, Apellido, Wapp, Calle, Numero, Localidad, Observación, Correo)
                VALUES
            ('" + _cliente.Nombre + "','" + _cliente.Apellido + "', '" + _cliente.Wapp + "','" + _cliente.Calle + "', '" + _cliente.Numero + "', '" + _cliente.Localidad + "', '" + _cliente.Observacion + "', '" + _cliente.Correo + "', 'false')";

            using (var conex = new SqlConnection())
            {

                traer.HacerTransaccion(comando);

            }

        }


    }
}
