using Entidades; 
using AccesoDatos;
using System.Data;
using Microsoft.Data.SqlClient; 

namespace Negocio
{
     public class ProdNegocio
     {
        Productos miProducto = new Productos(); 
        List<Productos> misProductos = new List<Productos>();
        List<Precios> misPrecios = new List<Precios>(); 

        public List<Productos> RecuperarProductos (){

            String _comando = "SELECT * FROM PRODUCTOS WHERE Baja='false';";

            try
            {
                using (var conex = new SqlConnection())
                {
                    AccesoBase traer = new AccesoBase();
                    var dataT = new DataTable();
                    dataT = traer.TraerDataT(_comando);

                    var prod = new Productos();

                    foreach (DataRow fila in dataT.Rows)
                    {
                        prod = new Productos();
                        prod.Codigo = int.Parse(fila[0].ToString()!);
                        prod.Nombre = fila[1].ToString() ?? "sin data";
                        prod.Marca = fila[2].ToString() ?? "sin data";  //2
                        prod.Categoria = fila[3].ToString() ?? "sin data"; //3
                        prod.StockActual = double.Parse(fila[5].ToString() ?? "0"); //5 - double
                        prod.UnidadGranel = int.Parse(fila[7].ToString() ?? "0"); //7

                        misProductos.Add(prod);
                    }

                }

            } catch (Exception e){

                Console.WriteLine($"Error: {e.Message} - {e.StackTrace}");
            }

                return misProductos;

        }

        public List<Precios> RecuperarPrecios() {

            String _comando = "SELECT * FROM PRODUCTOSPRECIOS;";

            // me interesa solo buscar en tabal precio venta, unidad y el ¿idProducto?
            // idProducto (int)1, PredioVenta Double 4, Unidad string 5
            try
            {
                using (var conex = new SqlConnection())
                {
                    AccesoBase traer = new AccesoBase();
                    var dataT = new DataTable();
                    dataT = traer.TraerDataT(_comando);

                    var precio = new Precios(); 

                    foreach (DataRow fila in dataT.Rows)
                    {
                        precio.Producto.Codigo =int.Parse(fila[1].ToString()!);
                        precio.PrecioVenta = double.Parse(fila[4].ToString() ?? "0");
                        precio.Unidad = fila[5].ToString() ?? "sin data";

                        misPrecios.Add(precio);
                    }

                }

            }
            catch (Exception e)
            {

                Console.WriteLine($"Error: {e.Message} - {e.StackTrace}");
            }

            return misPrecios;

        }

        //unificar productos en Precios 

        public List<Precios> CargarProdPrecios() {

            misProductos = RecuperarProductos();
            misPrecios = RecuperarPrecios();

            for( int i=0; i<misPrecios.Count; i++)
            {
                for (int a=0; a<misProductos.Count; a++)
                {
                    if (misPrecios[i].Producto.Codigo == misProductos[a].Codigo)
                    {
                        misPrecios[i].Producto = misProductos[a];
                    }
                }
            }
            return misPrecios;
        }

    }


}
    
