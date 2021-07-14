using System.Web.Mvc;

namespace NIRAC_WEB.Controllers
{
    [Autentica(Modulo = "FluxoCaixa", TipoAcesso = "NIRAC-ALL", Funcionalidade = "FluxoCaixa")]
    public class FluxoCaixaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}