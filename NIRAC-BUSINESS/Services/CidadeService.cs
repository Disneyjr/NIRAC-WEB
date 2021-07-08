using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Interface;
using NIRAC_BUSINESS.Interface.Map;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;
using NIRAC_BUSINESS.Repository;

namespace NIRAC_BUSINESS.Services
{
    public class CidadeService : ServiceBase<CidadeDAO, CidadeDTO, ContextDb, CidadeRepository>
    {
        public CidadeService(ContextDb cx, CidadeRepository rep, MapBase<CidadeDAO, CidadeDTO> configuration) : base(cx, rep, configuration)
        {
        }
    }
}
