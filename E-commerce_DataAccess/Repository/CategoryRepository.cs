using E_commerce_DataAccess.Data;
using E_commerce_DataAccess.Repository.IRepository;
using E_commerce_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_DataAccess.Repository
{
    public class CategoryRepository :Repository<Category>, ICategoryRepository
    {
        private readonly AppDBContext _dbContext;
        public CategoryRepository(AppDBContext appDBContext):base(appDBContext)
        {
            _dbContext = appDBContext;
                
        }
        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
