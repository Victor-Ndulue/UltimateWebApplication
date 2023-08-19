using System.Linq.Expressions;

namespace Contracts
{
    public interface IRepositoryBase<T>
    { 
        IQueryable<T> FindAllAsync(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
