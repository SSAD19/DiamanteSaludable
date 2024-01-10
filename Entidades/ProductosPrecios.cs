
namespace Entidades
{
    public class ProductosPrecios
    {
        Productos producto { get; set; }
        double PrecioVenta { get; set; }
        string Unidad { get; set; }
        bool Baja { get; set; }

        public ProductosPrecios(){}
    }
}