using NIRAC_BUSINESS.API_CONFIG;
using NIRAC_BUSINESS.Models.DTO;
using System.Collections.Generic;

namespace NIRAC_WEB.WebServices
{
    public class CobrancaWebService
    {
        private readonly ApiConfiguration api;
        private readonly WebServiceBase<EmprestimoDTO> _emprestimoBase;
        public CobrancaWebService()
        {
            api = new ApiConfiguration();
            _emprestimoBase = new WebServiceBase<EmprestimoDTO>(this.api.URI_API);
        }
        public List<EmprestimoDTO> ListarEmprestimos(int idEmpresa)
        {
            return _emprestimoBase.GetListFindInt(idEmpresa, "Emprestimo/BuscaEmprestimosPeloIdEmpresa/");
        }
    }
}