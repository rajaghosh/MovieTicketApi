namespace MovieTicketApi.DBContext.CoreRepository
{
    public interface IDbRepository<TEntity> : IDisposable
    {
        DbConnection GetDbconnection();
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
//private readonly MTDbContext _dbContext;

//public MTDbRepository(MTDbContext dbContext)
//{
//    _dbContext = dbContext;
//}

//public async Task<TEntity> GetByIdAsync(int id)
//{
//    return await _dbContext.Set<TEntity>().FindAsync(id);
//}

//public async Task<IEnumerable<TEntity>> GetAllAsync()
//{
//    return await _dbContext.Set<TEntity>().ToListAsync();
//}

//public async Task AddAsync(TEntity entity)
//{
//    await _dbContext.Set<TEntity>().AddAsync(entity);
//    await _dbContext.SaveChangesAsync();
//}

//public async Task UpdateAsync(TEntity entity)
//{
//    _dbContext.Set<TEntity>().Update(entity);
//    await _dbContext.SaveChangesAsync();
//}

//public async Task DeleteAsync(TEntity entity)
//{
//    _dbContext.Set<TEntity>().Remove(entity);
//    await _dbContext.SaveChangesAsync();
//}