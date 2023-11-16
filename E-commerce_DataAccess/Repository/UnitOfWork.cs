using E_commerce_DataAccess.Data;
using E_commerce_DataAccess.Repository.IRepository;
using E_commerce_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        private AppDBContext _dbContext;
        public UnitOfWork(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
            Category = new CategoryRepository(_dbContext);
            Product = new ProductRepository(_dbContext);
        }


        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
