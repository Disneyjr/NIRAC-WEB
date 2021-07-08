using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Interface;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;
using NIRAC_BUSINESS.Models.Map;
using NIRAC_BUSINESS.Repository;

namespace NIRAC_BUSINESS.Services
{
    public class PaisService : ServiceBase<PaisDAO, PaisDTO, ContextDb, PaisRepository>
    {
        public PaisService(ContextDb cx, PaisRepository rep, PaisMap map) : base(cx, rep, map)
        { }
    }
}
