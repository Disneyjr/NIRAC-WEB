using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Interface;
using NIRAC_BUSINESS.Models.DAO;

namespace NIRAC_BUSINESS.Repository
{
    public class CentroCustoRepository : RepositoryBase<ContextDb, CentroCustoDAO>
    {
        public CentroCustoRepository(ContextDb cx) : base(cx)
        {
        }
    }
}
