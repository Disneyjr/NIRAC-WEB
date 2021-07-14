using System.Web.Mvc;

namespace NIRAC_WEB.Controllers
{
    [Autentica(Modulo = "Perfil", TipoAcesso = "NIRAC-ALL", Funcionalidade = "Perfil")]
    public class PerfilController : Controller
    {
        public ActionResult PerfilUsuario()
        {
            return View();
        }
    }
}