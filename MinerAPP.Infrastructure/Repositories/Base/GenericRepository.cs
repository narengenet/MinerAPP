using Microsoft.EntityFrameworkCore;
using MinerAPP.Application.Interfaces.Base;
using MinerAPP.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerAPP.Infrastructure.Repositories.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        /*
            This is where we communicate with database,
            and it stands for all the classes.              
         */
        private readonly AppDbContext _dbContext;
        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            SaveChanges();
        }

        public IReadOnlyList<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
