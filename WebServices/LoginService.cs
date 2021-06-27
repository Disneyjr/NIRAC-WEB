using NIRAC_BUSINESS.API_CONFIG;
using NIRAC_BUSINESS.DAO;
using NIRAC_BUSINESS.DTO;

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
        public bool VerificaLogin(string User, string Password)
        {
            bool retorno = false;
            var usuario = this._ususerviceBase.GetUserPassword(User, Password);
            if (usuario.Id > 0)
            {
                retorno = true;
            }
            return retorno;
        }
    }
}