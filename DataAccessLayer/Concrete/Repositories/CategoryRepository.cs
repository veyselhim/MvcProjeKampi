using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository:ICategoryDal
    {
        private readonly Context context = new Context();
        private DbSet<Category> _object;

        public CategoryRepository(DbSet<Category> o)
        {
            _object = o;
        }

        public List<Category> List()
        {
            return _object.ToList();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(Category category)
        {
            _object.Add(category);

            context.SaveChanges();
        }


        public void Update(Category category)
        {
            context.SaveChanges();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category category)
        {
            _object.Remove(category);

            context.SaveChanges();
        }
    }
}
