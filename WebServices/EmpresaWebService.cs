using System.Collections.Generic;
using NIRAC_BUSINESS.API_CONFIG;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;

namespace NIRAC_WEB.WebServices
{
    public class EmpresaWebService
    {
        private ApiConfiguration api;
        private WebServiceBase<EmpresaDAO> _empresaBase;
        private WebServiceBase<PaisDTO> _paisBase;
        private WebServiceBase<EstadoDTO> _estadoBase;
        private WebServiceBase<CidadeDTO> _cidadeBase;
        public EmpresaWebService()
        {
            this.api = new ApiConfiguration();
            this._empresaBase = new WebServiceBase<EmpresaDAO>(this.api.URI_API);
            this._paisBase = new WebServiceBase<PaisDTO>(this.api.URI_API);
            this._estadoBase = new WebServiceBase<EstadoDTO>(this.api.URI_API);
            this._cidadeBase = new WebServiceBase<CidadeDTO>(this.api.URI_API);
        }
        public bool Add(EmpresaDAO empresaDAO)
        {
            var response = _empresaBase.Add(empresaDAO, "Empresa");
            if (response.Id > 0)
                return true;
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
    }
}