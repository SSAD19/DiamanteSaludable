using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Precios { 
        public Productos Producto { get; set; }
        public double PrecioVenta { get; set; }
        public string Unidad { get; set; }

        public Precios() { }
    }
}
