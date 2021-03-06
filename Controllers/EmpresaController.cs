using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;
using NIRAC_BUSINESS.Services;
using NIRAC_WEB.WebServices;

namespace NIRAC_WEB.Controllers
{
    [Autentica(Modulo = "Empresa", TipoAcesso = "NIRAC-ALL")]
    public class EmpresaController : Controller
    {
        private EmpresaWebService empresaService;
        public EmpresaController()
        {
            empresaService = new EmpresaWebService();
        }

        public ActionResult Index()
        {
            EmpresaDAO empresaDAO = BuscarPaisEstadoCidade();
            return View(empresaDAO);
        }

        public ActionResult Cadastrar()
        {
            ViewBag.ListaPaises = empresaService.ListarPaises();
            List<EmpresaUsuarioDTO> empresaUsuarioDTOs = empresaService.ListarEmpresaUsuario();
            int idUsuario = Convert.ToInt32(Request.Cookies.Get("Id").Value);
            EmpresaUsuarioDTO empresaUsuarioDTO = empresaUsuarioDTOs.Find(l => l.IdUsuario == idUsuario);
            if(empresaUsuarioDTO == null)
                return View();
            else
                return RedirectToAction("Index", "Empresa");
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
            int idUsuario = Convert.ToInt32(Request.Cookies.Get("Id").Value);
            var empresacadastrada = empresaService.EmpresaCadastrada(idUsuario);
            if (empresacadastrada != null)
            {
                TempData["warning"] = "O Usuario ja possui uma Empresa!";
                return RedirectToAction("Cadastrar", "Empresa");
            }
                
            EmpresaDAO empresaDAO = new EmpresaDAO();
            string dinheiro = form["EmpresaDAO.DinheiroCaixa"].ToString();
            string nome = form["EmpresaDAO.Nome"].ToString();
            string pais = form["pais"].ToString();
            string estado = form["estado"].ToString();
            string cidade = form["cidade"].ToString();
            empresaDAO.IdUsuarioAdm = idUsuario;
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
            EmpresaDAO empresaDAO = BuscarPaisEstadoCidade();
            int idUsuario = Convert.ToInt32(Request.Cookies.Get("Id").Value);
            return View(empresaService.EmpresaCadastrada(idUsuario));
        }
        [HttpPost]
        public ActionResult Editar(FormCollection form)
        {
            return View();
        }

        public EmpresaDAO BuscarPaisEstadoCidade(  )
        {
            int idUsuario = Convert.ToInt32(Request.Cookies.Get("Id").Value);
            EmpresaDAO empresaDAO = empresaService.EmpresaCadastrada(idUsuario);
            int idPais = Convert.ToInt32(empresaDAO.IdPais);
            List<EstadoDTO> estadoDTOs = empresaService.ListarEstados(idPais);
            PaisDTO paisDTO = empresaService.ListarPaises().Find(l => l.Id == idPais);
            EstadoDTO estadoDTO = estadoDTOs.Find(l => l.Id == empresaDAO.IdEstado);
            CidadeDTO cidadeDTO = empresaService.ListarCidades(estadoDTO.Id).Find(l => l.Id == empresaDAO.IdCidade);
            ViewData["pais"] = paisDTO.Nome;
            ViewData["estado"] = estadoDTO.Nome;
            ViewData["cidade"] = cidadeDTO.Nome;
            return empresaDAO;
        }
    }
}