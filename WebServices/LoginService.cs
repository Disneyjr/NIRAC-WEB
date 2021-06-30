using System.Web;
using NIRAC_BUSINESS.API_CONFIG;
using NIRAC_BUSINESS.DAO;
using NIRAC_BUSINESS.Models.API_CONFIG;

namespace NIRAC_WEB.WebServices
{
    public class LoginService
    {
        private ApiConfiguration api;
        private WebServiceBase<UsuarioDAO> _ususerviceBase;
        public LoginService()
        {
            this.api = new ApiConfiguration();
            this._ususerviceBase = new WebServiceBase<UsuarioDAO>(this.api.URI_API, "Usuario");
        }
        public UsuarioDAO VerificaLogin(string User, string Password)
        {
            bool retorno = false;
            var response = this._ususerviceBase.GetUserPassword(User);
            retorno = HashingSenha.ValidarSenha(Password, response.Senha);
            if (retorno)
            {
                return response;
            }
            else
            {
                return null;
            }
            
        }
        public bool ExistEmail(string Email)
        {
            bool retorno = false;
            var response = this._ususerviceBase.GetUserbyEmail(Email);
            if (response != null)
            {
                retorno = true;
            }
            return retorno;
        }
        public bool AdicionarUsuario(UsuarioDAO usuario)
        {
            bool retorno = false;
            var response = this._ususerviceBase.Add(usuario);
            if (response != null)
            {
                retorno = true;
            }
            return retorno;
        }
    }
}