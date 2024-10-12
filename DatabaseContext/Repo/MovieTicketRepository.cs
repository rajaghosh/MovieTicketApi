using Microsoft.EntityFrameworkCore;

namespace MovieTicketApi.DatabaseContext.Repo
{
    public class MovieTicketRepository<TEntity> : IMovieTicketRepository<TEntity> where TEntity : class
    {
        private readonly MovieTicketDbContext _dbContext;

        public MovieTicketRepository(MovieTicketDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
