using AccesoDatos;
using Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Negocio
{
    public class PedNegocio
    {
        // solo hará altas 

        //alta pedido como tal 
         public void AltaPedido (Pedidos _pedido, List<ItemPedidos> _item) {
           
            string _query = @"
            INSERT INTO Pedidos (idCliente, FechaPedido, TotalPagar, Delivery, Descuento, TotalDescuento)
            VALUES (" + _pedido.Cliente.Codigo + ",'" + DateTime.Now + "', " + _pedido.TotalPagar + ",'"
            + _pedido.delivery + "', " + _pedido.Descuento + "," + _pedido.TotalDescuento + ");";
          
            
            
            try
            {
                using (var conex = new SqlConnection())
                {
                    var traer = new AccesoDB();
                    traer.HacerTransaccion(_query);

                    for (int i = 0; i<_item.Count; i++)
                    {
                        string _queryItem = @" INSERT INTO itemPedido (IdProducto, Cantidad, Subtotal)
                        VALUES
                        (" + _item[i].ProductoItem.Codigo + "," + _item[i].Cantidad + "," + _item[i].Subtotal + ");";

                        traer.HacerTransaccion(_queryItem);
                    }
                }

            } catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}, ruta: {e.StackTrace}");
            }


        }



    

    }
}
 