using NIRAC_BUSINESS.Models.DAO;
using NIRAC_WEB.WebServices;
using System;
using System.Web.Mvc;

namespace NIRAC_WEB.Controllers
{
    [Autentica(Modulo = "Emprestimo", TipoAcesso = "NIRAC-ALL")]
    public class EmprestimoController : Controller
    {
        private EmprestimoWebService emprestimoWebService;

        public EmprestimoController()
        {
            this.emprestimoWebService = new EmprestimoWebService();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cadastrar()
        {
            int idUsuarioAdm = Convert.ToInt32(Session["IdUsuario"]);
            ViewBag.ListaClientes = emprestimoWebService.GetClientes(idUsuarioAdm);
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
        public ActionResult EmprestimoCadastrar(EmprestimoDAO emprestimoDAO)
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