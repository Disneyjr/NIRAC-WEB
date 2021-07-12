using System;
using System.Web.Mvc;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.PrivateMethods;
using NIRAC_WEB.WebServices;

namespace NIRAC_WEB.Controllers
{
    public class EmpresaController : Controller
    {
        int idUsuario;
        private Estado estado = new Estado();
        private EmpresaService empresaService;
        private Cidade cidade = new Cidade();
        public EmpresaController()
        {
            this.idUsuario = Convert.ToInt32(Request.Cookies.Get("Id").Value);
            empresaService = new EmpresaService();
        }
        // GET: Empresa
        public ActionResult Index()
        {
            ViewBag.CadastrouEmpresa = false;
            return View();
        }
        public ActionResult Cadastrar()
        {
            ViewBag.ListaPaises = empresaService.ListarPaises();
            return View();
        }
        [HttpPost]
        public ActionResult ListarEstados(int id)
        {
            return Json(new { Success = "true", EstadoDTOs = empresaService.ListarEstados(id) });
        }
        [HttpPost]
        public ActionResult ListarCidades(int id)
        {
            return Json(new { Success = "true", CidadeDTOs = empresaService.ListarCidades(id) });
        }
        [HttpPost]
        public ActionResult Cadastrar(FormCollection form)
        {
            var empresacadastrada = empresaService.EmpresaCadastrada(idUsuario);
            if (empresacadastrada.Id > 0)
            {
                TempData["error"] = "Falha ao Cadastrar a Empresa!";
                return RedirectToAction("Cadastrar", "Empresa");
            }
                
            EmpresaDAO empresaDAO = new EmpresaDAO();
            string dinheiro = form["EmpresaDAO.DinheiroCaixa"].ToString();
            string nome = form["EmpresaDAO.Nome"].ToString();
            string pais = form["pais"].ToString();
            string estado = form["estado"].ToString();
            string cidade = form["cidade"].ToString();
            empresaDAO.IdUsuario = idUsuario;
            empresaDAO.DataAtualizacao = DateTime.Now;
            empresaDAO.DataCriacao = DateTime.Now;
            empresaDAO.Nome = nome;
            empresaDAO.DinheiroCaixa = Convert.ToDecimal(dinheiro);
            empresaDAO.IdCidade = Convert.ToInt16(cidade);
            empresaDAO.IdEstado = Convert.ToInt16(estado);
            empresaDAO.IdPais = Convert.ToInt16(pais);
            if (empresaService.Add(empresaDAO))
            {
                TempData["success"] = "Empresa Cadastrada com Sucesso!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = "Falha ao Cadastrar a Empresa!";
                return RedirectToAction("Cadastrar", "Empresa");
            }
        }
        public ActionResult Editar()
        {
            return View(empresaService.EmpresaCadastrada(idUsuario));
        }
        [HttpPost]
        public ActionResult Editar(FormCollection form)
        {
            return View();
        }
    }
}