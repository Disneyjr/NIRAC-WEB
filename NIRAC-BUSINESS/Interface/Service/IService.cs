﻿using System.Collections.Generic;

namespace NIRAC_BUSINESS.Interface
{
    public interface IService<TDto, TDao> 
        where TDto : class
        where TDao : class
    {
        TDto Get(int id);
        List<TDto> GetAll();
        TDto Add(TDao t);
        TDto Update(TDao t);
        TDto Delete(TDao t);
    }
}
