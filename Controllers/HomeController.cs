using System.Collections.Generic;
using System.Web.Mvc;

namespace NIRAC_WEB.Controllers
{
    
    [Autentica(Modulo = "Home", Tipo = "Pre-Cadastrado", Funcionalidade = "Home")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}