using System.Linq.Expressions;
using ProStudy_NET.Models.classes;

namespace ProStudy_NET.Models.Interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
    IQueryable<TEntity>? GetAll(FindOptions? findOptions = null);
    TEntity? FindOne(Expression<Func<TEntity, bool>> predicate, FindOptions? findOptions = null);
    IQueryable<TEntity>? Find(Expression<Func<TEntity, bool>> predicate, FindOptions? findOptions = null);
    void Add(TEntity entity);
    void AddMany(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void DeleteMany(Expression<Func<TEntity, bool>> predicate);
    bool Any(Expression<Func<TEntity, bool>> predicate);
    int Count(Expression<Func<TEntity, bool>> predicate);
    }
}