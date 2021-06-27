using System.Collections.Generic;

namespace NIRAC_BUSINESS.Interface
{
    public interface IRepository<T> where T:class
    {
        T Add(T t);
        T Get(int id);
        List<T> GetAll();
        T Delete(T t);
        T Update(T t);
    }
}
