using NIRAC_BUSINESS.Models.DAO;

namespace NIRAC_BUSINESS.Models.DTO
{
    public class EmpresaUsuarioDTO
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEmpresa { get; set; }
        public EmpresaDAO empresaDAO { get; set; }
        public UsuarioDAO usuarioDAO { get; set; }
    }
}
