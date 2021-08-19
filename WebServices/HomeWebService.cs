using NIRAC_BUSINESS.API_CONFIG;
using NIRAC_BUSINESS.Models.DTO;

namespace NIRAC_WEB.WebServices
{
    public class HomeWebService
    {
        private ApiConfiguration api;
        private WebServiceBase<EmpresaDTO> _empresaService;
        public HomeWebService()
        {
            api = new ApiConfiguration();
            _empresaService = new WebServiceBase<EmpresaDTO>(this.api.URI_API);
        }
        public EmpresaDTO GetEmpresa(int idUsuario)
        {
           return _empresaService.GetEntityFindInt(idUsuario, "Empresa/BuscaEmpresaCadastradaPeloIdUsuarioAdm/");
        }
    }
}