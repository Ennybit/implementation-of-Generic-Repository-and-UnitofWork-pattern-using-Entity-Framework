using GenericRepo.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GenericRepo.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly datacontext _context;
        private readonly DbSet<T> _dbSet; 
        public GenericRepository(datacontext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
    
        public async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var found = await _dbSet.FindAsync(id);
            if (found != null)
            _dbSet.Remove(found);   
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null, List<string>? includes = null)
        {
            IQueryable<T> query = _dbSet;
            if(expression != null)
            {
                query = query.Where(expression);
            }

            if(orderby != null)
            {
                query = orderby(query);
            }

            if(includes != null)
            {
                foreach(var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> Getbyid(Expression<Func<T, bool>>? expression, List<string>? includes = null)
        {
            IQueryable<T> query = _dbSet;
            if(includes != null)
            {
                foreach(var IncludeProperty in includes)
                {
                    query = query.Include(IncludeProperty);
                }
            }


            return await  query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
