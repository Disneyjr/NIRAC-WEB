using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Interface;
using NIRAC_BUSINESS.Interface.Map;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;
using NIRAC_BUSINESS.Repository;

namespace NIRAC_BUSINESS.Services
{
    public class ParcelaService : ServiceBase<ParcelaDAO, ParcelaDTO, ContextDb, ParcelaRepository>
    {
        public ParcelaService(ContextDb cx, ParcelaRepository rep, MapBase<ParcelaDAO, ParcelaDTO> configuration) : base(cx, rep, configuration)
        {
        }
    }
}
