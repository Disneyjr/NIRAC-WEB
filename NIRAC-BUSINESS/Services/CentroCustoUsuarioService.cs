using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Interface;
using NIRAC_BUSINESS.Interface.Map;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;
using NIRAC_BUSINESS.Repository;

namespace NIRAC_BUSINESS.Services
{
    public class CentroCustoUsuarioService : ServiceBase<CentroCustoUsuarioDAO, CentroCustoUsuarioDTO, ContextDb, CentroCustoUsuarioRepository>
    {
        public CentroCustoUsuarioService(ContextDb cx, CentroCustoUsuarioRepository rep, MapBase<CentroCustoUsuarioDAO, CentroCustoUsuarioDTO> configuration) : base(cx, rep, configuration)
        {
        }
    }
}
