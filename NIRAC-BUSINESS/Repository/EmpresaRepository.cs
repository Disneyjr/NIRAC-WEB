using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Interface;
using NIRAC_BUSINESS.Models.DAO;

namespace NIRAC_BUSINESS.Repository
{
    public class EmpresaRepository : RepositoryBase<ContextDb, EmpresaDAO>
    {
        public EmpresaRepository(ContextDb cx) : base(cx)
        {
        }
    }
}
