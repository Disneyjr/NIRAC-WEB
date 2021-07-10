using System.Collections.Generic;
using System.Data.Entity;
using AutoMapper;
using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Interface.Map;
using NIRAC_BUSINESS.Models.Map;

namespace NIRAC_BUSINESS.Interface
{
    public class ServiceBase<TDao, TDto, Context, Repository> : IService<TDto,TDao>
        where TDao : class
        where TDto : class
        where Context : DbContext
        where Repository: IRepository<TDao>
    {
        private Repository rep;
        public Repository repository { get { return this.repository; } }
        private Context cx;
        public Context context { get { return this.cx; } }
        private IMapper mapper;
        private MapperConfiguration configuration;
        public IMapper Mapper
        {
            get{ return this.mapper; }
            set { this.mapper = value; }
        }
        protected MapperConfiguration Configuration 
        { 
            get { return this.configuration; }
            set { this.configuration = value; }
        } 
        public ServiceBase(Context cx, Repository rep, MapBase<TDao,TDto> configuration):base()
        {
            this.mapper = configuration.Registrar(this.Configuration);
            this.cx = cx;
            this.rep = rep;
        }

        public TDto Get(int id)
        {
            TDao dao = this.rep.Get(id);
            TDto dto = this.mapper.Map<TDto>(dao);
            return dto;
        }

        public List<TDto> GetAll()
        {
            List<TDao> listDao = this.rep.GetAll();
            List<TDto> listDto = this.mapper.Map<List<TDto>>(listDao);
            return listDto;
        }

        public TDto Add(TDao t)
        {
            TDao dao = this.rep.Add(t);
            TDto dto = this.mapper.Map<TDto>(dao);
            return dto;
        }

        public TDto Update(TDao t, int id)
        {
            TDao dao = this.rep.Update(t, id);
            TDto dto = this.mapper.Map<TDto>(dao);
            return dto;
        }

        public TDto Delete(TDao t, int id)
        {
            TDao dao = this.rep.Delete(t, id);
            TDto dto = this.mapper.Map<TDto>(dao);
            return dto;
        }

        public TDto DAOToDTO(TDao t)
        {
            return this.mapper.Map<TDto>(t);
        }

        public TDao DTOToDAO(TDto t)
        {
            return this.mapper.Map<TDao>(t);
        }
    }
}
