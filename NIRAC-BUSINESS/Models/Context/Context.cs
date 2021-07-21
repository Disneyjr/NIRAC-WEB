using System.Data.Entity;
using NIRAC_BUSINESS.Models.DAO;

namespace NIRAC_BUSINESS.Context
{
    public class ContextDb: DbContext
    {
        public ContextDb(): base("name=NIRACDB")
        { }
        public virtual DbSet<UsuarioDAO> Usuarios { get; set; }
        public virtual DbSet<EmpresaDAO> Empresas { get; set; }
        public virtual DbSet<PaisDAO> Paises { get; set; }
        public virtual DbSet<EmpresaUsuarioDAO> EmpresaUsuarios { get; set; }
        public virtual DbSet<CentroCustoDAO> CentroCustos { get; set; }
        public virtual DbSet<CentroCustoUsuarioDAO> CentroCustoUsuarios { get; set; }
        public virtual DbSet<EstadoDAO> Estados { get; set; }
        public virtual DbSet<CidadeDAO> Cidades { get; set; }
        public virtual DbSet<ParcelaDAO> Parcelas { get; set; }
        public virtual DbSet<EmprestimoDAO> Emprestimos { get; set; }
    }
}
