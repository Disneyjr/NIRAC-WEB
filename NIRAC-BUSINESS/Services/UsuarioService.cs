using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.DAO;
using NIRAC_BUSINESS.DTO;
using NIRAC_BUSINESS.Interface;
using NIRAC_BUSINESS.Models.Map;
using NIRAC_BUSINESS.Repository;

namespace NIRAC_BUSINESS.Services
{
    public class UsuarioService : ServiceBase<UsuarioDAO,UsuarioDTO, ContextDb, UsuarioRepository>
    {
        public UsuarioService(ContextDb cx, UsuarioRepository rep, UsuarioMap map) :base(cx, rep, map)
        { }
    }
}
