using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Interface;
using NIRAC_BUSINESS.Models.DAO;

namespace NIRAC_BUSINESS.Repository
{
    public class EmprestimoRepository : RepositoryBase<ContextDb, EmprestimoDAO>
    {
        public EmprestimoRepository(ContextDb cx) : base(cx)
        { }
    }
}
