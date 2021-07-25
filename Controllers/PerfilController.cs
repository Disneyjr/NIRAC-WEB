using System.Web.Mvc;

namespace NIRAC_WEB.Controllers
{
    [Autentica(Modulo = "Perfil", TipoAcesso = "NIRAC-ALL")]
    public class PerfilController : Controller
    {
        public ActionResult PerfilUsuario()
        {
            return View();
        }
    }
}