using System;
using System.Web.Mvc;
using NIRAC_BUSINESS.Models.API_CONFIG;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.PrivateMethods;
using NIRAC_WEB.WebServices;

namespace NIRAC_WEB.Controllers
{
    [Autentica(Modulo = "Usuario", TipoAcesso = "NIRAC-ALL", Funcionalidade = "Usuario")]
    public class UsuarioController : Controller
    {
        private UsuarioWebService usuarioService;
        private ToFromGenero toFromGenero;
        private ToFromEstadoCivil toFromEstadoCivil;
        private ToFromFuncionarios toFromFuncionario;
        public UsuarioController()
        {
            toFromGenero = new ToFromGenero();
            toFromEstadoCivil = new ToFromEstadoCivil();
            toFromFuncionario = new ToFromFuncionarios();
            usuarioService = new UsuarioWebService();
        }
        public ActionResult Funcionarios()
        {
            return View(usuarioService.GetUsuariosFindType("Funcionario", "Usuario/GetUserType/"));
        }
        public ActionResult FuncionarioCadastrar()
        {
            ViewBag.ListaPaises = usuarioService.ListarPaises();
            return View();
        }
        [HttpPost]
        public ActionResult FuncionarioCadastrar(UsuarioDAO usuarioDAO, FormCollection form, string confirmarSenha)
        {
            if (!confirmarSenha.Equals(usuarioDAO.Senha))
            {
                TempData["error"] = "As senhas estão diferentes!";
                return RedirectToAction("FuncionarioCadastrar", "Usuario");
            }
            string genero = form["genero"].ToString();
            string estadocivil = form["estadocivil"].ToString();
            string tipo = form["tipo"].ToString();
            string pais = form["pais"].ToString();
            string estado = form["estado"].ToString();
            string cidade = form["cidade"].ToString();
            usuarioDAO.IdPais = Convert.ToInt16(pais);
            usuarioDAO.IdEstado = Convert.ToInt16(estado);
            usuarioDAO.IdCidade = Convert.ToInt16(cidade);
            usuarioDAO.Genero = toFromGenero.Genero(Convert.ToInt16(genero));
            usuarioDAO.Tipo = toFromFuncionario.Funcionario(Convert.ToInt16(tipo));
            usuarioDAO.EstadoCivil = toFromEstadoCivil.EstadoCivil(Convert.ToInt16(estadocivil));
            usuarioDAO.Data_Cadastro = DateTime.Now;
            usuarioDAO.Data_Update = DateTime.Now;
            usuarioDAO.TipoAcesso = "NIRAC-FUNCIONARIO";
            usuarioDAO.Status = "Ativo";
            usuarioDAO.Tipo = "Funcionario";
            usuarioDAO.Senha = HashingSenha.HashSenha(usuarioDAO.Senha);
            if (usuarioService.AdicionarUsuario(usuarioDAO))
            {
                TempData["success"] = "Funcionario Cadastrada com Sucesso!";
                return RedirectToAction("Funcionarios", "Usuario");
            }
            else
            {
                TempData["error"] = "Falha ao Cadastrar o Funcionario!";
                return RedirectToAction("FuncionarioCadastrar", "Usuario");
            }
        }
        public ActionResult FuncionarioEditar(int id)
        {
            return View(usuarioService.GetUsuario(id));
        }
        public ActionResult Clientes()
        {
            return View(usuarioService.GetUsuariosFindType("Cliente", "Usuario/GetUserType/"));
        }
        public ActionResult ClienteCadastrar()
        {
            ViewBag.ListaPaises = usuarioService.ListarPaises();
            return View();
        }
        [HttpPost]
        public ActionResult ClienteCadastrar(UsuarioDAO usuarioDAO, FormCollection form, string confirmarSenha)
        {
            if (!confirmarSenha.Equals(usuarioDAO.Senha))
            {
                TempData["error"] = "As senhas estão diferentes!";
                return RedirectToAction("FuncionarioCadastrar", "Usuario");
            }
            string genero = form["genero"].ToString();
            string estadocivil = form["estadocivil"].ToString();
            string tipo = form["tipo"].ToString();
            string pais = form["pais"].ToString();
            string estado = form["estado"].ToString();
            string cidade = form["cidade"].ToString();
            usuarioDAO.IdPais = Convert.ToInt16(pais);
            usuarioDAO.IdEstado = Convert.ToInt16(estado);
            usuarioDAO.IdCidade = Convert.ToInt16(cidade);
            usuarioDAO.Genero = toFromGenero.Genero(Convert.ToInt16(genero));
            usuarioDAO.Tipo = toFromFuncionario.Funcionario(Convert.ToInt16(tipo));
            usuarioDAO.EstadoCivil = toFromEstadoCivil.EstadoCivil(Convert.ToInt16(estadocivil));
            usuarioDAO.Data_Cadastro = DateTime.Now;
            usuarioDAO.Data_Update = DateTime.Now;
            usuarioDAO.TipoAcesso = "NIRAC-CLIENTE";
            usuarioDAO.Status = "Ativo";
            usuarioDAO.Tipo = "Cliente";
            usuarioDAO.Senha = HashingSenha.HashSenha(usuarioDAO.Senha);
            if (usuarioService.AdicionarUsuario(usuarioDAO))
            {
                TempData["success"] = "Cliente Cadastrada com Sucesso!";
                return RedirectToAction("Funcionarios", "Usuario");
            }
            else
            {
                TempData["error"] = "Falha ao Cadastrar o Cliente!";
                return RedirectToAction("FuncionarioCadastrar", "Usuario");
            }
        }
        public ActionResult ClienteEditar(int id)
        {
            return View(usuarioService.GetUsuario(id));
        }
    }
}