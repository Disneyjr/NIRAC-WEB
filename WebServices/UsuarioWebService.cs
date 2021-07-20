using System.Collections.Generic;
using NIRAC_BUSINESS.API_CONFIG;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;

namespace NIRAC_WEB.WebServices
{
    public class UsuarioWebService
    {
        private ApiConfiguration api;
        private WebServiceBase<UsuarioDTO> _ususerviceBase;
        private WebServiceBase<UsuarioDAO> _ususerviceBaseDAO;
        private WebServiceBase<PaisDTO> _paisBase;
        public UsuarioWebService()
        {
            this.api = new ApiConfiguration();
            this._paisBase = new WebServiceBase<PaisDTO>(this.api.URI_API);
            this._ususerviceBase = new WebServiceBase<UsuarioDTO>(this.api.URI_API);
            this._ususerviceBaseDAO = new WebServiceBase<UsuarioDAO>(this.api.URI_API);
        }
        public List<UsuarioDTO> GetUsuariosFindType(string FieldString, string Research)
        {
            return _ususerviceBase.GetListFindString(FieldString, Research);
        }
        public UsuarioDTO GetUsuario(int id)
        {
            return _ususerviceBase.Get(id, "Usuario/");
        }
        public bool AdicionarUsuario(UsuarioDAO usuario)
        {
            bool retorno = false;
            var response = _ususerviceBaseDAO.Add(usuario, "Usuario");
            if (response != null)
            {
                retorno = true;
            }
            return retorno;
        }
        public bool DeletarUsuario(int id, UsuarioDTO usuarioDTO)
        {
            bool retorno = false;
            var response = _ususerviceBase.Delete(usuarioDTO, id, "Usuario/");
            if (response != null)
            {
                retorno = true;
            }
            return retorno;
        }
        public List<PaisDTO> ListarPaises()
        {
            return _paisBase.GetAll("Pais");
        }
    }
}