using System.ComponentModel.DataAnnotations.Schema;

namespace NIRAC_BUSINESS.Models.DAO
{
    [Table("Cidade")]
    public class CidadeDAO
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [ForeignKey("estadoDAO")]
        public int? IdEstado { get; set; }
        public EstadoDAO estadoDAO { get; set; }
    }
}
