using System.Linq.Expressions;
using ProStudy_NET.Models.classes;
using ProStudy_NET.Models.Interfaces;

namespace ProStudy_NET.Component.DB.Abstract
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ProStudyDB context;

        public Repository(ProStudyDB context)
        {
            this.context = context;
        }
        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void AddMany(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().AddRange(entities);
            context.SaveChanges();
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Any(predicate);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
             return context.Set<TEntity>().Count(predicate);
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public void DeleteMany(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> entities = context.Set<TEntity>().Where(predicate);
            context.Set<TEntity>().RemoveRange(entities);
            context.SaveChanges();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, FindOptions? findOptions = null)
        {
            IQueryable<TEntity> query = context.Set<TEntity>().Where(predicate);

            return query;
        }

        public TEntity? FindOne(Expression<Func<TEntity, bool>> predicate, FindOptions? findOptions = null)
        {
            IQueryable<TEntity> query = context.Set<TEntity>().Where(predicate);
            
            return query.FirstOrDefault();
        }

        public IQueryable<TEntity> GetAll(FindOptions? findOptions = null)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            return query;
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }
    }
}