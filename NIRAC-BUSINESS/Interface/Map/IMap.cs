using AutoMapper;

namespace NIRAC_BUSINESS.Interface.Map
{
    public interface IMap
    {
        IMapper Registrar(MapperConfiguration configuration);
    }
}
