
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Configuration;
using Entidades;
using Negocio;

namespace WebApplication1.Pages
{

      public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;

            Inicializar(); 
        }
       
        public List<Productos> listadoProd { get; private set; }
        Productos productos = new Productos();
        ProdNegocio accProd = new ProdNegocio();


        //este m�todo trae la lista de productos con sus precios ya unificado 
        private void Inicializar()
        {
            /*string conexString = _config.GetConnectionString("DefaultConnection");
            string conexString = @"Data Source=DESKTOP-P0J7R4I\SQLEXPRESS;Initial Catalog=Diamante; Integrated Security=true;Encrypt=False;";
            */

            listadoProd = accProd.RecuperarProductos(listadoProd);

            Console.WriteLine(listadoProd[0].Nombre);

        }


        public void OnGet()
        {
        }
       



    }
}
