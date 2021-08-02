using NIRAC_BUSINESS.Models.DTO;
using NIRAC_WEB.WebServices;
using System;
using System.Web.Mvc;

namespace NIRAC_WEB.Controllers
{

    [Autentica(Modulo = "Home", TipoAcesso = "NIRAC-ALL")]
    public class HomeController : Controller
    {
        private HomeWebService _service = new HomeWebService();
        public ActionResult Index()
        {
            GetTotais(_service.GetEmpresa(Convert.ToInt32(Session["IdUsuario"])));
            return View();
        }
        private void GetTotais(EmpresaDTO empresa)
        {
            ViewBag.GanhosMensal = empresa.TotalGanhosMensal > 0 ? empresa.TotalGanhosMensal : 0;
            ViewBag.GanhosAnual = empresa.TotalGanhosAnual > 0 ? empresa.TotalGanhosAnual : 0;
            ViewBag.RecebidoMensal = empresa.TotalRecebidoMensal > 0 ? empresa.TotalRecebidoMensal : 0;
            ViewBag.Pendentes = empresa.TotalPendentes > 0 ? empresa.TotalPendentes : 0;
        }
    }
}