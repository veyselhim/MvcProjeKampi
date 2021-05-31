using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.Repositories.EfRepository
{
    public class GenericRepository<T>:IRepository<T> where T: class
    {
        private readonly Context context = new Context();

        private readonly DbSet<T> _object;

        public GenericRepository()
        {
            _object = context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _object.ToList();
        }

        public T GetById(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
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

        public List<T> Get(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }
    }
}
