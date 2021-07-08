using NIRAC_BUSINESS.Models.DAO;

namespace NIRAC_BUSINESS.Models.DTO
{
    public class EstadoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? IdPais { get; set; }
        public PaisDAO paisDAO { get; set; }
    }
}
