using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace MovieTicketApi.DBContext.CoreRepository
{
    //private readonly IConfiguration _config;
    //private string Connectionstring;

    //public AppDapper(IConfiguration config)
    //{
    //    _config = config;
    //    Connectionstring = "DefaultConnection";
    //    MarketPlaceConnectionString = "MarketPlaceConnection";
    //}


    //public DbConnection GetDbconnection()
    //{
    //    return new SqlConnection(_config.GetConnectionString(Connectionstring));
    //}


    public class DbRepository<TEntity> : IDbRepository<TEntity> where TEntity : class
    {
        //        private readonly MTDbContext _dbContext;

        //        public MTDbRepository(MTDbContext dbContext)
        //        {
        //            _dbContext = dbContext;
        //        }

        //        public async Task<TEntity> GetByIdAsync(int id)
        //        {
        //            return await _dbContext.Set<TEntity>().FindAsync(id);
        //        }

        private readonly IConfiguration _config;
        private string Connectionstring;
        private readonly MTContext _dbContext;

        public DbRepository(IConfiguration config, MTContext dbContext)
        {
            _config = config;
            _dbContext = dbContext;
            Connectionstring = "MovieTicketDb";
        }

        public DbConnection GetDbconnection()
        {
            return new SqlConnection(_config.GetConnectionString(Connectionstring));
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }

    //public class DbRepository : IDapper
    //{

    //}
}
//namespace MovieTicketApi.DBContext
//{
//    public class MTDbRepository<TEntity> where TEntity : class
//    {
//        private readonly MTDbContext _dbContext;

//        public MTDbRepository(MTDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task<TEntity> GetByIdAsync(int id)
//        {
//            return await _dbContext.Set<TEntity>().FindAsync(id);
//        }

//        public async Task<IEnumerable<TEntity>> GetAllAsync()
//        {
//            return await _dbContext.Set<TEntity>().ToListAsync();
//        }

//        public async Task AddAsync(TEntity entity)
//        {
//            await _dbContext.Set<TEntity>().AddAsync(entity);
//            await _dbContext.SaveChangesAsync();
//        }

//        public async Task UpdateAsync(TEntity entity)
//        {
//            _dbContext.Set<TEntity>().Update(entity);
//            await _dbContext.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(TEntity entity)
//        {
//            _dbContext.Set<TEntity>().Remove(entity);
//            await _dbContext.SaveChangesAsync();
//        }
//    }
//}

namespace MovieTicketApi.DBContext
{
    public class DbRepository<TEntity> where TEntity : class
    {
        private readonly MTContext _dbContext;

        public DbRepository(MTContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
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
    }
}

