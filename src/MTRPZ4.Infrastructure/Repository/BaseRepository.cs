using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MTRPZ4.Infrastructure.Repository.IRepository;

namespace MTRPZ4.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDBContext _dbContext;
        public BaseRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity?> GetById(int? id)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            return await _dbContext.Set<TEntity>()
                .FindAsync(id);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>()
                .AddAsync(entity);
        }

        public void Update(TEntity? entity)
        {
            _dbContext.Set<TEntity>()
                .Update(entity);
        }
    }
}
