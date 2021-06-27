using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.DAO;
using NIRAC_BUSINESS.Interface;

namespace NIRAC_BUSINESS.Repository
{
    public class UsuarioRepository : RepositoryBase<ContextDb,UsuarioDAO>
    {
        public UsuarioRepository(ContextDb cx):base(cx)
        { }
    }
}
