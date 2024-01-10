using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Productos
    {
        public int Codigo { get; set; }
        public String Nombre { get; set; }
        public String Marca { get; set; }
        public String Categoria { get; set; }
        public double StockActual { get; set; }
        public int UnidadGranel { get; set; } //esto es lo que me va a definir 
        public bool Baja { get; set; }

        public Productos()
        {
        }

    }
}
