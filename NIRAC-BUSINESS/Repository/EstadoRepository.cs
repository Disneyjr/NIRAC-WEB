using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Interface;
using NIRAC_BUSINESS.Models.DAO;

namespace NIRAC_BUSINESS.Repository
{
    public class EstadoRepository : RepositoryBase<ContextDb, EstadoDAO>
    {
        public EstadoRepository(ContextDb cx) : base(cx)
        {
        }
    }
}
