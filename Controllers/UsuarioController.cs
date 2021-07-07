using System.Web.Mvc;

namespace NIRAC_WEB.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Funcionarios()
        {
            return View();
        }
        public ActionResult FuncionarioCadastrar()
        {
            return View();
        }
        public ActionResult FuncionarioEditar()
        {
            return View();
        }
        public ActionResult Clientes()
        {
            return View();
        }
        public ActionResult ClienteCadastrar()
        {
            return View();
        }
        public ActionResult ClienteEditar()
        {
            return View();
        }
    }
}