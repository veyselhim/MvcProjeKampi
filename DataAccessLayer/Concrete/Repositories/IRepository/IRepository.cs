using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> GetAll();

        T GetById(Expression<Func<T, bool>> filter);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        List<T> Get(Expression<Func<T,bool>> filter);
    }
}
