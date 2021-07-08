using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NIRAC_BUSINESS.DAO;

namespace NIRAC_BUSINESS.Models.DAO
{
    [Table("CentroCustoUsuario")]
    public class EmpresaUsuarioDAO
    {
            [Column("Id"), Key]
            public int Id { get; set; }
            [ForeignKey("usuarioDAO")]
            public int? IdUsuario { get; set; }
            [ForeignKey("empresaDAO")]
            public int? IdEmpresa { get; set; }
            public EmpresaDAO empresaDAO { get; set; }
            public UsuarioDAO usuarioDAO { get; set; }
        }
}
