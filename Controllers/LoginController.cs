﻿using System;
using System.Web;
using System.Web.Mvc;
using NIRAC_BUSINESS.DAO;
using NIRAC_BUSINESS.Models.API_CONFIG;
using NIRAC_WEB.Validations;
using NIRAC_WEB.WebServices;

namespace NIRAC_WEB.Controllers
{
    public class LoginController : Controller
    {
        private LoginService loginService;
        private HashingSenha hashing;
        public LoginController()
        {
            loginService = new LoginService();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string User, string Password)
        {
            var usuario = loginService.VerificaLogin(User, Password);
            if (usuario != null)
            {
                HttpCookie cookie = new HttpCookie("Id");
                HttpCookie cookieUsuarioTipo = new HttpCookie("Tipo");
                cookie.Path = "/";
                cookieUsuarioTipo.Path = "/";
                cookie.Value = usuario.Id.ToString();
                cookieUsuarioTipo.Value = usuario.Tipo;
                Response.Cookies.Add(cookie);
                Response.Cookies.Add(cookieUsuarioTipo);
                TempData["success"] = "Logado com Sucesso!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = "Erro ao tentar Logar!";
            }

            return RedirectToAction("Index", "Login");
        }
        public ActionResult CadastroUsuario()
        {
            return View();
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
            usuario.Genero = DeParaGenero(Convert.ToInt16((genero)));
            usuario.EstadoCivil = DeParaEstadoCivil(Convert.ToInt16((estadoCivil)));
            int local = usuario.Nome.IndexOf(" ");
            usuario.Apelido = usuario.CPF.Substring(0,3) +"_"+ usuario.Nome.Remove(local);
            usuario.Data_Cadastro = DateTime.Now;
            usuario.Data_Update = DateTime.Now;
            usuario.Tipo = "Pre-Cadastrado";
            usuario.IdCidade = 1;
            usuario.IdEstado = 1;
            usuario.IdPais = 1;
            usuario.Senha = HashingSenha.HashSenha(usuario.Senha);
            if (loginService.AdicionarUsuario(usuario))
            {
                TempData["success"] = "Usuario Cadastrado com Sucesso!";
                return RedirectToAction("Index", "Login");
            }
            else
            {
                TempData["error"] = "Falha ao Cadastrar o Usuario!";
                return RedirectToAction("CadastroUsuario", "Login");
            }
        }
        public string DeParaGenero(int genero)
        {
            string retorno = "";
            if (genero == 1)
                retorno = "Masculino";
            if (genero == 2)
                retorno = "Feminino";
            return retorno;
        }
        public string DeParaEstadoCivil(int estadocivil)
        {
            string retorno = "";
            if (estadocivil == 1)
                retorno = "Solteiro";
            if (estadocivil == 2)
                retorno = "Casado";
            if (estadocivil == 3)
                retorno = "Separado";
            if (estadocivil == 4)
                retorno = "Divorciado"; 
            if (estadocivil == 5)
                retorno = "Viúvo";
            return retorno;
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