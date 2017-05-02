using HRSS.ManageMyNotes.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRSS.ManageMyNotes.Repository
{
    public class RepositoryBase<TEntity, TDbContext>: IRepository<TEntity, TDbContext> where TEntity : EntityBase where TDbContext : DbContext, new()
    {
        private TDbContext context = new TDbContext();
        public int Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAllFiltered(Expression<Func<TEntity, bool>> criteria)
        {
            return context.Set<TEntity>().Where(criteria).ToList();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
    public interface IRepository<TEntity, TDbContext>:IDisposable
    {
        int Add(TEntity entity);
        IEnumerable<TEntity> GetAllFiltered(Expression<Func<TEntity,bool>> criteria);
    }
}
