using E_commerce_DataAccess.Data;
using E_commerce_DataAccess.Repository.IRepository;
using E_commerce_DataAccess.Repository;
using E_commerce_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_DataAccess.Repository
{
    public class CompanyRepository:Repository<Company>, ICompanyRepository
    {
        private readonly AppDBContext _dbContextt;
        public CompanyRepository(AppDBContext appDBContext):base(appDBContext)
        {
            _dbContextt = appDBContext;
                
        }
       

        public void Update(Company obj)
        {
            _dbContextt.Update(obj);
        }
    }
}
