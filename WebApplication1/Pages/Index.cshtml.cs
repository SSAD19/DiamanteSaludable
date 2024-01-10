
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Configuration;


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

        }

        public void OnGet()
        {
        }


        /*
        public void ConectarDB() {

        AccesoDatos.AccesoBase conexDB = new AccesoDatos.AccesoBase();
        string conexString = _config.GetConnectionString("DefaultConnection");

            conexDB.AbrirConex(conexString); 

    }
        */

        




    }
}
