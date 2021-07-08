using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NIRAC_BUSINESS.DAO;

namespace NIRAC_BUSINESS.Models.DAO
{
    [Table("CentroCustoUsuario")]
    public class CentroCustoUsuarioDAO
    {
        [Column("Id"), Key]
        public int Id { get; set; }
        [ForeignKey("custoDAO")]
        public int? IdCentroCusto { get; set; }
        [ForeignKey("usuarioDAO")]
        public int? IdUsuario { get; set; }
        public CentroCustoDAO custoDAO { get; set; }
        public UsuarioDAO usuarioDAO { get; set; }
    }
}
