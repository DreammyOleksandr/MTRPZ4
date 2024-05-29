using MTRPZ4.CoreDomain.Entities;
using MTRPZ4.Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTRPZ4.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _dbContext;
        public IBaseRepository<Color> Colors { get; private set; }
        public IBaseRepository<Font> Fonts { get; private set; }
        public IBaseRepository<Price> Prices { get; private set; }
        public UnitOfWork(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            Colors = new BaseRepository<Color>(_dbContext);
            Fonts = new BaseRepository<Font>(_dbContext);
            Prices = new BaseRepository<Price>(_dbContext);
        }
        
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
