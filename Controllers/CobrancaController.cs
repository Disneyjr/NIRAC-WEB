using NIRAC_WEB.WebServices;
using System;
using System.Web.Mvc;

namespace NIRAC_WEB.Controllers
{
    [Autentica(Modulo = "Cobranca", TipoAcesso = "NIRAC-FUNCIONARIO")]
    public class CobrancaController : Controller
    {
        private CobrancaWebService cobrancaService;
        public CobrancaController()
        {
            cobrancaService = new CobrancaWebService();
        }
        public ActionResult CobrancaIndex()
        {
            int idEmpresa = 0;
            idEmpresa = Convert.ToInt32(Session["IdUsuario"]);
            ViewBag.ListaCobranca = cobrancaService.ListarEmprestimos(idEmpresa);
            return View();
        }
    }
}