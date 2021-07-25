using NIRAC_BUSINESS.API_CONFIG;
using NIRAC_BUSINESS.Models.DAO;
using System.Collections.Generic;

namespace NIRAC_WEB.WebServices
{
    public class EmprestimoWebService
    {
        private ApiConfiguration api;
        private WebServiceBase<EmprestimoDAO> _emprestimoBase;
        private WebServiceBase<UsuarioDAO> _usuarioBase;
        public EmprestimoWebService()
        {
            this.api = new ApiConfiguration();
            this._emprestimoBase = new WebServiceBase<EmprestimoDAO>(this.api.URI_API);
            this._usuarioBase = new WebServiceBase<UsuarioDAO>(this.api.URI_API);
        }

        public List<UsuarioDAO> GetClientes(int idUsuario)
        {
            return _usuarioBase.GetListFindInt(idUsuario, "Usuario/BuscaClientesPeloIdUsuarioAdm/");
        }
    }
}