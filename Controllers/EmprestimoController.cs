using System.Web.Mvc;

namespace NIRAC_WEB.Controllers
{
    [Autentica(Modulo = "Emprestimo", TipoAcesso = "NIRAC-ALL", Funcionalidade = "Emprestimo")]
    public class EmprestimoController : Controller
    {
        public ActionResult Index()
        {
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
        [HttpPost]
        public ActionResult EmprestimoEditar()
        {
            return null;
        }
        [HttpPost]
        public ActionResult EmprestimoCadastrar()
        {
            return null;
        }
        [HttpPost]
        public ActionResult EmprestimoDeletar()
        {
            return null;
        }
    }
}