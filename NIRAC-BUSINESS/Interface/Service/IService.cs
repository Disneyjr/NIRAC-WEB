using System.Collections.Generic;

namespace NIRAC_BUSINESS.Interface
{
    public interface IService<TDto, TDao> 
        where TDto : class
        where TDao : class
    {
        TDto Get(int id);
        TDao GetDAO(int id);
        List<TDto> GetAll();
        TDto Add(TDao t);
        TDto Update(TDao t, int id);
        TDto Delete(TDao t, int id);
        TDto DAOToDTO(TDao t);
        TDao DTOToDAO(TDto t);

    }
}
