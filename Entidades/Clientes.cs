namespace Entidades {
    public class Clientes {

        int Codigo { get; set; }
		string Nombre { get; set; }
        string Apellido { get; set; }
        string Wapp { get; set; } // numero de whatsapp ¿?
        string Calle { get; set; }
        string Numero { get; set; }
        string Localidad { get; set; } //  barrio es localidad o departamento 
        string Observacion { get; set; } // referencias 
        string Correo{ get; set; }
		DateTime FechaAlta { get; set; } // ¿solo tomar date ??
		bool baja { get; set; }

        public Clientes(){}

    }

}