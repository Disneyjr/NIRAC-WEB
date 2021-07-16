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
            cx.Set<T>().Add(t);
            cx.SaveChanges();
            return t;
        }

        public T Delete(T t, int id)
        {
            var tlocal = Get(id);
            cx.Entry(tlocal).State = EntityState.Detached;
            cx.Entry(t).State = EntityState.Deleted;
            cx.SaveChanges();
            return t;
        }

        public T Get(int id)
        {
            return cx.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return cx.Set<T>().ToList();
        }

        public T Update(T t, int id)
        {
            var tlocal = Get(id);
            cx.Entry(tlocal).State = EntityState.Detached;
            cx.Entry(t).State = EntityState.Modified;
            cx.SaveChanges();
            return t;
        }
    }
}
