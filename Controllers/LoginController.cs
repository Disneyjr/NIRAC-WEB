using System.Web.Mvc;
using NIRAC_WEB.WebServices;

namespace NIRAC_WEB.Controllers
{
    public class LoginController : Controller
    {
        private LoginService loginService;
        public LoginController()
        {
            loginService = new LoginService();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string User, string Password)
        {
            if (loginService.VerificaLogin(User, Password))
            {
                TempData["success"] = "Logado com Sucesso!";
            }
            else
            {
                TempData["error"] = "Erro ao tentar Logar!";
            }

            return RedirectToAction("Index", "Login");
        }
    }
}