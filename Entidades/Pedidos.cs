namespace Name
{
    public class Pedidos
    {
        int IdPedido { get; set; }
        Clientes Cliente { get; set; }
        DateTime FechaPedido { get; set; }
        double TotalPagar { get; set; }
        bool delivery { get; set; }
        bool Descuento { get; set; }
        double TotalDescuento { get; set; }

        public Pedidos(){}

    }
    }