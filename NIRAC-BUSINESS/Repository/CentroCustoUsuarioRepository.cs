using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Interface;
using NIRAC_BUSINESS.Models.DAO;

namespace NIRAC_BUSINESS.Repository
{
    public class CentroCustoUsuarioRepository : RepositoryBase<ContextDb, CentroCustoUsuarioDAO>
    {
        public CentroCustoUsuarioRepository(ContextDb cx) : base(cx)
        {
        }
    }
}
