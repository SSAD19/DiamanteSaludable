namespace Entidades
{
    public class ItemPedidos{
        public int IdItemPedido  { get; set;}
        public Productos ProductoItem { get; set; } // en producto poner precio  unitario¿?
        public double Cantidad { get; set; }
        public double Subtotal { get; set; }


        public ItemPedidos(){}
    }
}