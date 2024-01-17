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

        // uno igual por un producto nada mas¿?
        public List<Productos> RecuperarProductos(ref List<Productos> misProductos)
        {

            //query 
            string _query = @"Select p.Codigo, p.Nombre, p.Marca, p.Categoria, p.StockActual, p.UnidadGranel, pr.PrecioVenta, pr.Unidad
                FROM Productos as p
                Join ProductosPrecios as pr ON p.Codigo = pr.IdProducto 
                WHERE p.Baja='false';";

            //recuperarDB - desde capabase de datos que debe regresarme el dataTable
            try
            {
                using (var dataB = new AccesoDB())
                {
                    DataTable tabla = new DataTable();
                    tabla = dataB.TraerDataT(_query);

                    var prod = new Productos();

                    foreach (DataRow fila in tabla.Rows)
                    {
                        prod = new Productos();

                        prod.Codigo = int.Parse(fila[0].ToString()!);
                        prod.Nombre = fila[1].ToString() ?? " ";
                        prod.Marca = fila[2].ToString() ?? " ";
                        prod.Categoria = fila[3].ToString() ?? " ";
                        prod.StockActual = double.Parse(fila[4].ToString() ?? "0");
                        prod.UnidadGranel = int.Parse(fila[5].ToString() ?? "0");
                        prod.PrecioVenta = double.Parse(fila[6].ToString() ?? "0");
                        prod.Unidad = fila[7].ToString() ?? " ";

                        misProductos.Add(prod);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message} - {e.StackTrace}");
            }

            return misProductos;
        }
    }
}
