﻿using System;
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
          
        }
        public void Add(T entity)
        {
          dbSet.Add(entity);
        }
    

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query= query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
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
