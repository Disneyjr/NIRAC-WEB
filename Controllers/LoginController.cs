using System;
using System.Web;
using System.Web.Mvc;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.API_CONFIG;
using NIRAC_WEB.Validations;
using NIRAC_WEB.WebServices;
using NIRAC_BUSINESS.Models.PrivateMethods;

namespace NIRAC_WEB.Controllers
{
    public class LoginController : Controller
    {
        private LoginWebService loginService;
        private ToFromGenero toFromGenero;
        private ToFromEstadoCivil toFromEstadoCivil;
        public LoginController()
        {
            toFromGenero = new ToFromGenero();
            toFromEstadoCivil = new ToFromEstadoCivil();
            loginService = new LoginWebService();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string User, string Password)
        {
            try
            {
                var usuario = loginService.VerificaLogin(User, Password);
                if(usuario == null)
                    TempData["error"] = "Usuario não cadastrado!"; 
                HttpCookie cookie = new HttpCookie("Id");
                HttpCookie cookieUsuarioTipo = new HttpCookie("Tipo");
                HttpCookie cookieNomeUsuario = new HttpCookie("NomeUsuario");
                cookie.Path = "/";
                cookieUsuarioTipo.Path = "/";
                cookieNomeUsuario.Path = "/";
                cookie.Value = usuario.Id.ToString();
                cookieUsuarioTipo.Value = usuario.TipoAcesso;
                cookieNomeUsuario.Value = usuario.Nome;
                Response.Cookies.Add(cookie);
                Response.Cookies.Add(cookieUsuarioTipo);
                Response.Cookies.Add(cookieNomeUsuario);
                Session["UsuarioLogado"] = usuario.Nome;
                Session["IdUsuario"] = usuario.Id;
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                TempData["error"] = "Erro ao tentar Logar!";

                if (User == "" && Password == "")
                {
                    TempData["error"] = "Digite um Usuario e uma senha!";
                }
                else if (User == "" || User == null)
                {
                    TempData["error"] = "Digite um Usuario!";
                }
                else if (Password == "" || Password == null)
                {
                    TempData["error"] = "Digite uma Senha!";
                }
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult CadastroUsuario()
        {
            return View();
        }
        public ActionResult Deslogar()
        {
            Response.Cookies["Id"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Tipo"].Expires = DateTime.Now.AddDays(-1);
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        [Multiple_Buttons(Name = "action", Argument = "Cancel")]
        public ActionResult Voltar()
        {
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        [Multiple_Buttons(Name = "action", Argument = "Save")]
        public ActionResult CadastroUsuario(UsuarioDAO usuario, string Password2, FormCollection form)
        {
            if (!ValidacaoFomulario(usuario, Password2))
                return RedirectToAction("CadastroUsuario", "Login");

            string genero = form["Genero"].ToString();
            string estadoCivil = form["EstadoCivil"].ToString();
            usuario.Genero = toFromGenero.Genero(Convert.ToInt16(genero));
            usuario.EstadoCivil = toFromEstadoCivil.EstadoCivil(Convert.ToInt16(estadoCivil));
            int local = usuario.Nome.IndexOf(" ");
            usuario.Apelido = usuario.CPF.Substring(0, 3) + "_" + usuario.Nome.Remove(local);
            usuario.Data_Cadastro = DateTime.Now;
            usuario.Data_Update = DateTime.Now;
            usuario.Tipo = "Pre-Cadastrado";
            usuario.TipoAcesso = "Pre-Cadastrado";
            usuario.IdCidade = 1;
            usuario.IdEstado = 1;
            usuario.IdPais = 1;
            usuario.Senha = HashingSenha.HashSenha(usuario.Senha);
            if (loginService.AdicionarUsuario(usuario))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                TempData["error"] = "Falha ao Cadastrar o Usuario!";
                return RedirectToAction("CadastroUsuario", "Login");
            }
        }
        public bool ValidacaoFomulario(UsuarioDAO usuario, string Password2)
        {
            bool retorno = true;
            if (usuario == null)
            {
                TempData["warning"] = "Preencha todas as informações necessárias!";
                retorno = false;
                return retorno;
            }
            if (usuario.Senha != Password2)
            {
                TempData["warning"] = "A senha deve ser identica a confirmação da senha!";
                retorno = false;
                return retorno;
            }
            if (usuario.Email == null)
            {
                TempData["warning"] = "O Email não pode ser nullo";
                retorno = false;
                return retorno;
            }
            else
            {
                if (loginService.ExistEmail(usuario.Email))
                {
                    TempData["warning"] = "Email já cadastrado no sistema!";
                    retorno = false;
                    return retorno;
                }
            }
            return retorno;
        }
    }
}