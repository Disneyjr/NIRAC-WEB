using System.Collections.Generic;
using System.Web.Mvc;

namespace NIRAC_WEB.Controllers
{

    [Autentica(Modulo = "Home", TipoAcesso = "NIRAC-ALL", Funcionalidade = "Home")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.GanhosMensal = "";
            ViewBag.GanhosAnual = "";
            ViewBag.RecebidoMensal = "";
            ViewBag.Pendentes = "";
            return View();
        }
    }
}