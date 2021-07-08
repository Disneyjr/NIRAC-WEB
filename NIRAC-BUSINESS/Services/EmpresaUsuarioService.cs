using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Interface;
using NIRAC_BUSINESS.Interface.Map;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;
using NIRAC_BUSINESS.Repository;

namespace NIRAC_BUSINESS.Services
{
    public class EmpresaUsuarioService : ServiceBase<EmpresaUsuarioDAO, EmpresaUsuarioDTO, ContextDb, EmpresaUsuarioRepository>
    {
        public EmpresaUsuarioService(ContextDb cx, EmpresaUsuarioRepository rep, MapBase<EmpresaUsuarioDAO, EmpresaUsuarioDTO> configuration) : base(cx, rep, configuration)
        {
        }
    }
}
