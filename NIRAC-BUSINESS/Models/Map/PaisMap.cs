using NIRAC_BUSINESS.Interface.Map;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;

namespace NIRAC_BUSINESS.Models.Map
{
    public class PaisMap : MapBase<PaisDAO, PaisDTO>
    {
        public PaisMap():base()
        {
        }
    }
}
