using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Interface;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;
using NIRAC_BUSINESS.Models.Map;
using NIRAC_BUSINESS.Repository;

namespace NIRAC_BUSINESS.Services
{
    public class CentroCustoService : ServiceBase<CentroCustoDAO, CentroCustoDTO, ContextDb, CentroCustoRepository>
    {
        public CentroCustoService(ContextDb cx, CentroCustoRepository rep, CentroCustoMap map) : base(cx, rep, map)
        { }
    }
}
