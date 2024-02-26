using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Diagnostics.CodeAnalysis;

namespace E_commerce_DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {//T Category
        IEnumerable<T> GetAll(string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter, string includeProperties);//added to fix the error from get methode from homecontroller page ...to be deleted if not need
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
