using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Interface;
using NIRAC_BUSINESS.Models.DAO;

namespace NIRAC_BUSINESS.Repository
{
    public class UsuarioRepository : RepositoryBase<ContextDb,UsuarioDAO>
    {
        public UsuarioRepository(ContextDb cx):base(cx)
        { }
    }
}
