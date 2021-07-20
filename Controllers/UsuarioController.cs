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
        #region FUNCIONARIO
        public ActionResult Funcionarios()
        {
            var idUsuario = Convert.ToInt16(Session["IdUsuario"]);
            return View(usuarioService.GetUsuariosFindType("Funcionario/"+ idUsuario, "Usuario/GetUserType/"));
        }
        public ActionResult FuncionarioCadastrar()
        {
            ViewBag.ListaPaises = usuarioService.ListarPaises();
            return View();
        }
        public ActionResult FuncionarioEditar(int id)
        {
            return View(usuarioService.GetUsuario(id));
        }
        public ActionResult FuncionarioDetalhe(int id)
        {
            return View(usuarioService.GetUsuario(id));
        }
        public ActionResult FuncionarioDeletar(int id)
        {
            var usuario = usuarioService.GetUsuario(id);
            if (usuarioService.DeletarUsuario(id, usuario))
            {
                TempData["success"] = "Funcionario deletado com Sucesso!";
                return RedirectToAction("Funcionarios", "Usuario");
            }
            else
            {
                TempData["error"] = "Falha ao Deletar o Funcionario!";
                return RedirectToAction("Funcionarios", "Usuario");
            }
        }
        [HttpPost]
        public ActionResult FuncionarioCadastrar(UsuarioDAO usuarioDAO, FormCollection form, string confirmarSenha)
        {
            usuarioDAO.IdPais = Convert.ToInt16(form["pais"]);
            usuarioDAO.IdEstado = Convert.ToInt16(form["estado"]);
            usuarioDAO.IdCidade = Convert.ToInt16(form["cidade"]);
            usuarioDAO.Genero = toFromGenero.Genero(Convert.ToInt16(form["genero"]));
            usuarioDAO.Tipo = toFromFuncionario.Funcionario(Convert.ToInt16(form["tipo"]));
            usuarioDAO.EstadoCivil = toFromEstadoCivil.EstadoCivil(Convert.ToInt16(form["estadocivil"]));
            usuarioDAO.Data_Cadastro = DateTime.Now;
            usuarioDAO.Data_Update = DateTime.Now;
            usuarioDAO.TipoAcesso = "NIRAC-FUNCIONARIO";
            usuarioDAO.Status = "Ativo";
            usuarioDAO.Tipo = "Funcionario";
            usuarioDAO.IdUsuarioAdm = Convert.ToInt16(Session["IdUsuario"]);
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
        #endregion
        #region CLIENTE
        public ActionResult Clientes()
        {
            var idUsuario = Convert.ToInt16(Session["IdUsuario"]);
            return View(usuarioService.GetUsuariosFindType("Cliente/"+ idUsuario, "Usuario/GetUserType/"));
        }
        public ActionResult ClienteCadastrar()
        {
            ViewBag.ListaPaises = usuarioService.ListarPaises();
            return View();
        }
        public ActionResult ClienteEditar(int id)
        {
            return View(usuarioService.GetUsuario(id));
        }
        public ActionResult ClienteDetalhe(int id)
        {
            return View(usuarioService.GetUsuario(id));
        }
        public ActionResult ClienteDeletar(int id)
        {
            var usuario = usuarioService.GetUsuario(id);
            if (usuarioService.DeletarUsuario(id, usuario))
            {
                TempData["success"] = "Cliente deletado com Sucesso!";
                return RedirectToAction("Clientes", "Usuario");
            }
            else
            {
                TempData["error"] = "Falha ao Deletar o Cliente!";
                return RedirectToAction("Clientes", "Usuario");
            }
        }
        [HttpPost]
        public ActionResult ClienteCadastrar(UsuarioDAO usuarioDAO, FormCollection form, string confirmarSenha)
        {
            usuarioDAO.IdPais = Convert.ToInt16(form["pais"]);
            usuarioDAO.IdEstado = Convert.ToInt16(form["estado"]);
            usuarioDAO.IdCidade = Convert.ToInt16(form["cidade"]);
            usuarioDAO.Genero = toFromGenero.Genero(Convert.ToInt16(form["genero"]));
            usuarioDAO.Tipo = toFromFuncionario.Funcionario(Convert.ToInt16(form["tipo"]));
            usuarioDAO.EstadoCivil = toFromEstadoCivil.EstadoCivil(Convert.ToInt16(form["estadocivil"]));
            usuarioDAO.Data_Cadastro = DateTime.Now;
            usuarioDAO.Data_Update = DateTime.Now;
            usuarioDAO.TipoAcesso = "NIRAC-CLIENTE";
            usuarioDAO.Status = "Ativo";
            usuarioDAO.Tipo = "Cliente";
            usuarioDAO.IdUsuarioAdm = Convert.ToInt16(Session["IdUsuario"]);

            if (usuarioService.AdicionarUsuario(usuarioDAO))
            {
                TempData["success"] = "Cliente Cadastrada com Sucesso!";
                return RedirectToAction("Clientes", "Usuario");
            }
            else
            {
                TempData["error"] = "Falha ao Cadastrar o Cliente!";
                return RedirectToAction("ClienteCadastrar", "Usuario");
            }
        }
        #endregion
    }
}