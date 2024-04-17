
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using E_commerce_DataAccess.Data;
using E_commerce_DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDBContext _dbContext;
        internal DbSet<T> dbSet;
        public Repository(AppDBContext appDBContext)
        {
                _dbContext = appDBContext;
                this.dbSet = _dbContext.Set<T>();
            //  _dbContext.Products.Include(u => u.Category);
            _dbContext.Products.Include(u => u.Category).Include(u=>u.CategoryId);

          
        }
        public void Add(T entity)
        {
          dbSet.Add(entity);
        }


        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }


        // added to fix an error whit get methot  homecontroller (this is provisoire to be deleted if not  need)
        public T Get(Expression<Func<T, bool>> filter, string? includeProperties)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }
        ///end





        //Category,add CategoryType in the Productlist
        public IEnumerable<T> GetAll(string? includeProperties=null)
        { 
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            { 
            foreach (var property in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries)) 
                {
                query=query.Include(property);
                }
            }
            return query.ToList(); 
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
           dbSet.RemoveRange(entities);
        }

       
       
    }
}
