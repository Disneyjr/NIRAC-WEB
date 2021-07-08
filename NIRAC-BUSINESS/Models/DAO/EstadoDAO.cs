using System.ComponentModel.DataAnnotations.Schema;

namespace NIRAC_BUSINESS.Models.DAO
{
    [Table("Estado")]
    public class EstadoDAO
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [ForeignKey("paisDAO")]
        public int? IdPais { get; set; }
        public PaisDAO paisDAO { get; set; }
    }
}
