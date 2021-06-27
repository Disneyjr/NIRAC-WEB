using System.Web.Mvc;

namespace NIRAC_WEB.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string User, string Password)
        {
            /*
             Autenticação basica verificar somente o nome do usuario e a senha.
            Mandar para a api uma requisição e esperar a resposta.
             */
            TempData["success"] = "Mensagem de sucesso!!";
            return RedirectToAction("Index","Login");
        }
    }
}