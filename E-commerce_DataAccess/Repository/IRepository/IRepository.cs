using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace E_commerce_DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetAll(Expression<Func<T, bool>> filter);
        void Add(T entity);
        //void Delete(T entity);  
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
