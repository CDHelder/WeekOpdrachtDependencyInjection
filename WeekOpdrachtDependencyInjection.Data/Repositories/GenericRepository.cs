using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WeekOpdrachtDependencyInjection.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;
        private DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public void Create(T obj)
        {
            dbSet.Add(obj);
        }

        public void Delete(int id)
        {
            var obj = GetById(id);
            Delete(obj);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        //TODO: Check comment of die goed runnen via DeBugger
        public T Get(
            Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = dbSet;

            query = query.Where(filter);
            //query.Where(filter);

            if (include != null)
            {
                query = include(query);
            }
            //include?.Invoke(query);

            return query.FirstOrDefault();
        }

        public List<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
                return orderBy(query).ToList();
            else
                return query.ToList();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Update(T obj)
        {
            dbSet.Attach(obj);
            dbContext.Entry(obj).State = EntityState.Modified;

            dbSet.Update(obj);
        }

        public void Update(List<T> objs)
        {
            dbSet.UpdateRange(objs);
        }
    }
}
