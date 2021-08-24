using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NIRAC_BUSINESS.Models.API_CONFIG;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;
using NIRAC_BUSINESS.Models.PrivateMethods;
using NIRAC_WEB.WebServices;

namespace NIRAC_WEB.Controllers
{
    [Autentica(Modulo = "Usuario", TipoAcesso = "NIRAC-ALL")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioWebService usuarioService;
        private readonly ToFromGenero toFromGenero;
        private readonly ToFromEstadoCivil toFromEstadoCivil;
        private readonly ToFromFuncionarios toFromFuncionario;
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
            return View(usuarioService.GetUsuariosFindType("Funcionario/"+ idUsuario, "Usuario/BuscaUsuariosPeloTipoUsuarioEIdUsuario/"));
        }
        public ActionResult FuncionarioCadastrar()
        {
            ViewBag.Cidades = usuarioService.ListarCidades();
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
            usuarioDAO.IdPais = 1;
            usuarioDAO.IdEstado = 1;
            usuarioDAO.IdCidade = Convert.ToInt16(form["cidade"]);
            usuarioDAO.Genero = toFromGenero.Genero(Convert.ToInt16(form["genero"]));
            usuarioDAO.Tipo = toFromFuncionario.Funcionario(Convert.ToInt16(form["tipo"]));
            usuarioDAO.EstadoCivil = toFromEstadoCivil.EstadoCivil(Convert.ToInt16(form["estadocivil"]));
            int local = usuarioDAO.Nome.IndexOf(" ");
            usuarioDAO.Apelido = usuarioDAO.CPF.Substring(0, 3) + "_" + usuarioDAO.Nome.Remove(local);
            usuarioDAO.Data_Cadastro = DateTime.Now;
            usuarioDAO.Data_Update = DateTime.Now;
            usuarioDAO.TipoAcesso = "NIRAC-FUNCIONARIO";
            usuarioDAO.Status = "Ativo";
            usuarioDAO.Tipo = "Funcionario";
            usuarioDAO.IdUsuarioAdm = Convert.ToInt16(Session["IdUsuario"]);
            usuarioDAO.Senha = HashingSenha.HashSenha(usuarioDAO.Senha);
            if (usuarioService.AdicionarUsuario(usuarioDAO))
            {
                TempData["success"] = "Funcionario Cadastrado com Sucesso!";
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
            return View(usuarioService.GetUsuariosFindType("Cliente/"+ idUsuario, "Usuario/BuscaUsuariosPeloTipoUsuarioEIdUsuario/"));
        }
        public ActionResult ClienteCadastrar()
        {
            ViewBag.Cidades = usuarioService.ListarCidades();
            return View();
        }
        public ActionResult ClienteEditar(int id)
        {
            ViewBag.Cidades = usuarioService.ListarCidades();
            UsuarioDTO usuarioDTO = usuarioService.GetUsuario(id);
            return View(usuarioDTO);
        }

        public ActionResult Editar(UsuarioDAO usuarioDAO, FormCollection form)
        {
            usuarioDAO.IdCidade = Convert.ToInt16(form["cidade"]);
            usuarioDAO.Genero = toFromGenero.Genero(Convert.ToInt16(form["genero"]));
            usuarioDAO.EstadoCivil = toFromEstadoCivil.EstadoCivil(Convert.ToInt16(form["estadocivil"]));
            usuarioDAO.Id = Convert.ToInt32(Request.Cookies.Get("Id").Value);

            if (usuarioService.EditarUsuario(usuarioDAO))
            {
                TempData["success"] = "Cliente Alterado com Sucesso!";
                return RedirectToAction("Clientes", "Usuario");
            }
            else
            {
                TempData["error"] = "Falha ao Editar o Cliente!";
                return RedirectToAction("ClienteCadastrar", "Usuario");
            }
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
            usuarioDAO.IdPais = 1;
            usuarioDAO.IdEstado = 1;
            usuarioDAO.IdCidade = Convert.ToInt16(form["cidade"]);
            usuarioDAO.Genero = toFromGenero.Genero(Convert.ToInt16(form["genero"]));
            usuarioDAO.Tipo = toFromFuncionario.Funcionario(Convert.ToInt16(form["tipo"]));
            usuarioDAO.EstadoCivil = toFromEstadoCivil.EstadoCivil(Convert.ToInt16(form["estadocivil"]));
            usuarioDAO.Data_Cadastro = DateTime.Now;
            usuarioDAO.Data_Update = DateTime.Now;
            usuarioDAO.TipoAcesso = "NIRAC-CLIENTE";
            usuarioDAO.Status = "Ativo";
            usuarioDAO.Tipo = "Cliente";
            usuarioDAO.Indicacao = usuarioDAO.Indicacao;
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