using System.Linq.Expressions;

namespace GenericRepo.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync(
            Expression<Func<T, bool>>? expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null,
                List<string>? includes = null);  
        Task<T> Getbyid(Expression<Func<T, bool>>? expression, List<string>? includes = null);
        void Update(T entity);
        Task Delete(int id);
        Task Create(T entity);
    }
}
