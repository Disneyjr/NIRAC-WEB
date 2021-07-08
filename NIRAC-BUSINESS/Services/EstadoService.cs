using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Interface;
using NIRAC_BUSINESS.Interface.Map;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;
using NIRAC_BUSINESS.Repository;

namespace NIRAC_BUSINESS.Services
{
    public class EstadoService : ServiceBase<EstadoDAO, EstadoDTO, ContextDb, EstadoRepository>
    {
        public EstadoService(ContextDb cx, EstadoRepository rep, MapBase<EstadoDAO, EstadoDTO> configuration) : base(cx, rep, configuration)
        {
        }
    }
}
