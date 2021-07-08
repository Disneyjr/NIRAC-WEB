using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Interface;
using NIRAC_BUSINESS.Models.DAO;

namespace NIRAC_BUSINESS.Repository
{
    public class PaisRepository : RepositoryBase<ContextDb, PaisDAO>
    {
        public PaisRepository(ContextDb cx) : base(cx)
        {
        }
    }
}
