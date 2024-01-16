

namespace Entidades {
    public class Clientes {

        public int Codigo { get; set; }
        public  string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Wapp { get; set; } // numero de whatsapp ¿?
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Localidad { get; set; } //  barrio es localidad o departamento 
        public string Observacion { get; set; } // referencias 
        public string Correo{ get; set; }
        public DateTime FechaAlta { get; set; } // ¿solo tomar date ??
        public bool baja { get; set; }

         public Clientes() { }

    }

}