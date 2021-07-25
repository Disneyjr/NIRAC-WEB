using System;
using System.Web;
using NIRAC_BUSINESS.API_CONFIG;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.API_CONFIG;

namespace NIRAC_WEB.WebServices
{
    public class LoginWebService
    {
        private ApiConfiguration api;
        private WebServiceBase<UsuarioDAO> _ususerviceBase;
        public LoginWebService()
        {
            this.api = new ApiConfiguration();
            this._ususerviceBase = new WebServiceBase<UsuarioDAO>(this.api.URI_API);
        }
        public UsuarioDAO VerificaLogin(string User, string Password)
        {
            if (User == "" || Password == "")
                throw new Exception("Usuario ou senha Nullo!");
            var response = this._ususerviceBase.GetEntityFindString(User, "Usuario/BuscaUsuarioPeloApelido/");
            if (response == null)
                return null;
            if(HashingSenha.ValidarSenha(Password, response.Senha))
            {
                return response;
            }
            else
            {
                throw new Exception("Senha invalida!");
            }
            
        }
        public bool ExistEmail(string Email)
        {
            bool retorno = false;
            var response = this._ususerviceBase.GetEntityFindString(Email, "Usuario/BuscaUsuarioPeloEmail/");
            if (response != null)
            {
                retorno = true;
            }
            return retorno;
        }
        public bool AdicionarUsuario(UsuarioDAO usuario)
        {
            bool retorno = false;
            var response = this._ususerviceBase.Add(usuario,"Usuario");
            if (response != null)
            {
                retorno = true;
            }
            return retorno;
        }
    }
}