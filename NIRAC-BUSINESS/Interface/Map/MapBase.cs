using AutoMapper;

namespace NIRAC_BUSINESS.Interface.Map
{
    public class MapBase<TDao, TDto> : IMap where TDao : class where TDto : class
    {
        public IMapper Registrar(MapperConfiguration configuration)
        {
            configuration = new MapperConfiguration(cfg =>{
                cfg.CreateMap<TDao, TDto>();
                cfg.CreateMap<TDto,TDao>();
            });
            return configuration.CreateMapper();
        }
    }
}
