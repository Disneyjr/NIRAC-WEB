using System;
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
            try
            {
                cx.Set<T>().Add(t);
                cx.SaveChanges();
                return t;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public T Delete(T t, int id)
        {
            var tlocal = Get(id);
            cx.Entry(tlocal).State = EntityState.Detached;
            cx.Entry(t).State = EntityState.Deleted;
            try
            {
                cx.SaveChanges();
                return t;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public T Get(int id)
        {
            try
            {
                return cx.Set<T>().Find(id);
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public List<T> GetAll()
        {
            try
            {
                return cx.Set<T>().ToList();
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public T Update(T t, int id)
        {
            var tlocal = Get(id);
            cx.Entry(tlocal).State = EntityState.Detached;
            cx.Entry(t).State = EntityState.Modified;
            try
            {
                
                cx.SaveChanges();
                return t;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
