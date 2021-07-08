using System.Web.Mvc;

namespace NIRAC_WEB.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult Index()
        {
            ViewBag.CadastrouEmpresa = false;
            return View();
        }
        public ActionResult Cadastrar()
        {
            return View();
        }
        public ActionResult Editar()
        {
            return View();
        }
    }
}