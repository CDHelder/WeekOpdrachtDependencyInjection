using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WeekOpdrachtDependencyInjection.Data.Repositories
{
    public interface IGenericRepository<TEnitity> where TEnitity : class
    {
        List<TEnitity> GetAll(
            Expression<Func<TEnitity, bool>> filter = null,
            Func<IQueryable<TEnitity>,IOrderedQueryable<TEnitity>> orderBy = null,
            Func<IQueryable<TEnitity>, IIncludableQueryable<TEnitity, object>> include = null);
        TEnitity Get(
            Expression<Func<TEnitity, bool>> filter,
            Func<IQueryable<TEnitity>, IIncludableQueryable<TEnitity, object>> include = null);
        TEnitity GetById(int id);
        void Create(TEnitity obj);
        void Update(TEnitity obj);
        void Update(List<TEnitity> objs);
        void Delete(int id);
        void Delete(TEnitity entity);
    }
}
