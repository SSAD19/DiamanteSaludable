namespace Entidades
{
    public class Pedidos
    {
        public int IdPedido { get; set; }
        public Clientes Cliente { get; set; }
        public DateTime FechaPedido { get; set; }
        public double TotalPagar { get; set; }
        public bool delivery { get; set; }
        public bool Descuento { get; set; }
        public double TotalDescuento { get; set; }

        public Pedidos(){}

    }
    }