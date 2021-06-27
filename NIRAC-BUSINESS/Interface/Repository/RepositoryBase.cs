using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NIRAC_BUSINESS.Interface
{
    public class RepositoryBase<C, T> : IRepository<T> 
        where T : class 
        where C : DbContext
    {
        private C cx;
        public C CX
        {
            get { return this.cx; }
        }
        public RepositoryBase(C cx)
        {
            this.cx = cx;
        }
        public T Add(T t)
        {
            return this.cx.Set<T>().Add(t);
        }

        public T Delete(T t)
        {
            this.cx.Entry(t).State = EntityState.Deleted;
            return t;
        }

        public T Get(int id)
        {
            return this.cx.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return this.cx.Set<T>().ToList();
        }

        public T Update(T t)
        {
            this.cx.Entry(t).State = EntityState.Modified;
            return t;
        }
    }
}
