using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Interface;
using NIRAC_BUSINESS.Models.DAO;

namespace NIRAC_BUSINESS.Repository
{
    public class ParcelaRepository : RepositoryBase<ContextDb, ParcelaDAO>
    {
        public ParcelaRepository(ContextDb cx) : base(cx)
        {
        }
    }
}
