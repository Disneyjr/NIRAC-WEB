using NIRAC_BUSINESS.Models.DAO;

namespace NIRAC_BUSINESS.Models.DTO
{
    public class CidadeDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? IdEstado { get; set; }
        public EstadoDAO EstadoDAO { get; set; }
    }
}
