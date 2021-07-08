using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Interface;
using NIRAC_BUSINESS.Interface.Map;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;
using NIRAC_BUSINESS.Repository;

namespace NIRAC_BUSINESS.Services
{
    public class EmpresaService : ServiceBase<EmpresaDAO, EmpresaDTO, ContextDb, EmpresaRepository>
    {
        public EmpresaService(ContextDb cx, EmpresaRepository rep, MapBase<EmpresaDAO, EmpresaDTO> configuration) : base(cx, rep, configuration)
        {
        }
    }
}
