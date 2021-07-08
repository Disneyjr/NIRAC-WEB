using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Interface;
using NIRAC_BUSINESS.Models.DAO;

namespace NIRAC_BUSINESS.Repository
{
    public class CidadeRepository : RepositoryBase<ContextDb, CidadeDAO>
    {
        public CidadeRepository(ContextDb cx) : base(cx)
        {
        }
    }
}
