using NIRAC_BUSINESS.Models.DAO;

namespace NIRAC_BUSINESS.Models.DTO
{
    public class CentroCustoUsuarioDTO
    {
        public int Id { get; set; }
        public int? IdCentroCusto { get; set; }
        public int? IdUsuario { get; set; }
        public CentroCustoDAO custoDAO { get; set; }
        public UsuarioDAO usuarioDAO { get; set; }
    }
}
