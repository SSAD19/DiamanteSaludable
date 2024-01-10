namespace Entidades
{
    public class ItemPedidos{
        int IdItemPedido  { get; set;}
        Productos ProductoItem { get; set; } // en producto poner precio  unitario¿?
        double Cantidad { get; set; }
        double Subtotal { get; set; }


        public ItemPedidos(){}
    }
}