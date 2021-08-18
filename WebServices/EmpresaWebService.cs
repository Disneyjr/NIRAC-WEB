using System.Collections.Generic;
using NIRAC_BUSINESS.API_CONFIG;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;

namespace NIRAC_WEB.WebServices
{
    public class EmpresaWebService
    {
        private readonly ApiConfiguration api;
        private readonly WebServiceBase<EmpresaDAO> _empresaBase;
        private readonly WebServiceBase<PaisDTO> _paisBase;
        private readonly WebServiceBase<EstadoDTO> _estadoBase;
        private readonly WebServiceBase<CidadeDTO> _cidadeBase;
        private readonly WebServiceBase<EmpresaUsuarioDTO> _empresaUsuarioBase;
        private readonly WebServiceBase<EmpresaUsuarioDAO> _empresaUsuBase;
        public EmpresaWebService()
        {
            this.api = new ApiConfiguration();
            this._empresaBase = new WebServiceBase<EmpresaDAO>(this.api.URI_API);
            this._empresaUsuBase = new WebServiceBase<EmpresaUsuarioDAO>(this.api.URI_API);
            this._paisBase = new WebServiceBase<PaisDTO>(this.api.URI_API);
            this._estadoBase = new WebServiceBase<EstadoDTO>(this.api.URI_API);
            this._cidadeBase = new WebServiceBase<CidadeDTO>(this.api.URI_API);
            this._empresaUsuarioBase = new WebServiceBase<EmpresaUsuarioDTO>(this.api.URI_API);
        }

        public bool Add(EmpresaDAO empresaDAO)
        {
            var response = _empresaBase.Add(empresaDAO, "Empresa");
            if (response.Id > 0)
            {
                EmpresaUsuarioDAO empresaUsuarioDAO = new EmpresaUsuarioDAO();
                empresaUsuarioDAO.IdEmpresa = response.Id;
                empresaUsuarioDAO.IdUsuario = empresaDAO.IdUsuarioAdm;
                _empresaUsuBase.Add(empresaUsuarioDAO, "EmpresaUsuario");
                return true;
            }
            return false;
        }
        public EmpresaDAO EmpresaCadastrada(int idUsuario)
        {
            return _empresaBase.GetEntityFindInt(idUsuario, "Empresa/BuscaEmpresaCadastradaPeloIdUsuarioAdm/");
        }
        public List<PaisDTO> ListarPaises()
        {
            return _paisBase.GetAll("Pais");
        }
        public List<EstadoDTO> ListarEstados(int idPais)
        {
            return _estadoBase.GetListFindInt(idPais, "Estado/BuscaEstadosPeloIdPais/");
        }
        public List<CidadeDTO> ListarCidades(int idEstado)
        {
            return _cidadeBase.GetListFindInt(idEstado, "Cidade/BuscaCidadesPeloIdEstado/");
        }

        public List<EmpresaUsuarioDTO> ListarEmpresaUsuario()
        {
            return _empresaUsuarioBase.GetAll("EmpresaUsuario");
        }
    }
}