using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Interface;
using NIRAC_BUSINESS.Interface.Map;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;
using NIRAC_BUSINESS.Repository;

namespace NIRAC_BUSINESS.Services
{
    public class EmprestimoService : ServiceBase<EmprestimoDAO, EmprestimoDTO, ContextDb, EmprestimoRepository>
    {
        public EmprestimoService(ContextDb cx, EmprestimoRepository rep, MapBase<EmprestimoDAO, EmprestimoDTO> configuration) : base(cx, rep, configuration)
        {
        }
    }
}
