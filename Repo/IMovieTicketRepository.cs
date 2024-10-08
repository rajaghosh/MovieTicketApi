namespace MovieTicketApi.Repo
{
    //public interface IMovieTicketRepository<TEntity> : IDisposable
    //{
    //    Task<TEntity> GetByIdAsync(int id);
    //    Task<IEnumerable<TEntity>> GetAllAsync();
    //    Task AddAsync(TEntity entity);
    //    Task UpdateAsync(TEntity entity);
    //    Task DeleteAsync(TEntity entity);
    //}    

    public interface IMovieTicketRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
