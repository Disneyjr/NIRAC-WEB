using System.Data.Entity;
using NIRAC_BUSINESS.DAO;

namespace NIRAC_BUSINESS.Context
{
    public class ContextDb: DbContext
    {
        public ContextDb(): base("name=NIRACDB")
        { }
        public virtual DbSet<UsuarioDAO> Usuarios { get; set; }
    }
}
