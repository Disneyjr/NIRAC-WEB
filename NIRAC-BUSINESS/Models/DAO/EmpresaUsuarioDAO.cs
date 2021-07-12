using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NIRAC_BUSINESS.Models.DAO
{
    [Table("EmpresaUsuario")]
    public class EmpresaUsuarioDAO
    {
        [Column("Id"), Key]
        public int Id { get; set; }
        [ForeignKey("usuarioDAO")]
        public int? IdUsuario { get; set; }
        public UsuarioDAO usuarioDAO { get; set; }
        [ForeignKey("empresaDAO")]
        public int? IdEmpresa { get; set; }
        public EmpresaDAO empresaDAO { get; set; }

    }
}
