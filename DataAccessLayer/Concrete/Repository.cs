using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        Context c = new Context();

        Microsoft.EntityFrameworkCore.DbSet<T> _object;
        //Degisiklik yapmadan onceki hali:  DbSet<T> _object;


        public Repository()
        {
            _object = c.Set<T>();
        }

        public void Delete(T p)
        {
            c.Remove(p);
            c.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _object.FirstOrDefault(where);
        }

        public T GetByID(int id)
        {
            return _object.Find(id);
        }

        public void Insert(T p)
        {
             c.Add(p);
             c.SaveChanges();
        }

        public List<T> List()
        {
            //return _object?.ToList() ?? new List<T>();

            //return _object.ToList();
          
                try
                {
                    return _object?.ToList() ?? new List<T>();
                }
                catch (System.InvalidOperationException ex)
                {
                    // Hata yönetimi burada
                    // Loglama veya başka bir işlem yapabilirsiniz.
                    return new List<T>();
                }
            

        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return _object.Where(where).ToList();
        }

        public void Update(T p)
        {
            c.Update(p);
             c.SaveChanges();
        }
    }
}
