using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T>:IRepository<T> where T: class
    {
        private Context context = new Context();

        private DbSet<T> _object;

        public GenericRepository()
        {
            _object = context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _object.ToList();
        }

        public void Add(T entity)
        {
            _object.Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _object.Remove(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.SaveChanges();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }
    }
}
