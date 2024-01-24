using AccesoDatos;
using Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Negocio
{
    public class NotiNegocio
    {
        //necesito recuperar todas las noticias  sin el cuerpo
        public List<Noticias> RecuperNoticias()
        {
            List<Noticias> listadoNot = new List<Noticias>();


            string _query = @"Select IdNoticia, Titulo, Resumen, UrlImagen
                FROM Noticias
                WHERE Baja='false';";

            //recuperarDB - desde capabase de datos que debe regresarme el dataTable
            try
            {
                using (var dataB = new AccesoDB())
                {
                    DataTable tabla = new DataTable();
                    tabla = dataB.TraerDataT(_query);

                    var nota = new Noticias();

                    foreach (DataRow fila in tabla.Rows)
                    {
                        nota = new Noticias();

                        nota.IdNoticias = int.Parse(fila[0].ToString()!);
                        nota.Titulo = fila[1].ToString() ?? " ";
                        nota.Resumen = fila[2].ToString() ?? " ";
                        nota.UrlImagen = fila[3].ToString() ?? "wwwroot\\assets\\web\\image-not-found.webp";

                        listadoNot.Add(nota);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message} - {e.StackTrace}");
            }

            return listadoNot;

        }



        //este se pide solo cuando se va a leer una  noticia puntual
        public String  RecuperaUna(Noticias _nota)
        {
            string _notaCuerpo = "";

            string _query = @"Select Cuerpo
                FROM Noticias
                WHERE IdNoticia=" + _nota.IdNoticias + ";";

            try
            {

                using (var conex = new SqlConnection())
                {
                    var traer = new AccesoDB();
                    traer.ObtenerUno(_query, _nota);
                    _notaCuerpo = _nota.Cuerpo;
                }
            }

            catch (Exception e)
            {

                Console.WriteLine($"Error: {e.Message} - {e.StackTrace}");
            }


            //logica para recuperar el cuerpo desde bas

            return _notaCuerpo;

        }
    }
}
