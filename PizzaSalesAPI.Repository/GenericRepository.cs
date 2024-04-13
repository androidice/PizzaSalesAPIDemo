using Microsoft.EntityFrameworkCore;
using PizzaSalesAPI.Domain;
using PizzaSalesAPI.Repository.Interfaces;

namespace PizzaSalesAPI.Repository
{
    public abstract class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        protected readonly PizzaSalesAPIContext _dbContext;

        protected GenericRepository(PizzaSalesAPIContext context)
        {
            _dbContext = context;
        }

        public async Task<T> GetById(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
