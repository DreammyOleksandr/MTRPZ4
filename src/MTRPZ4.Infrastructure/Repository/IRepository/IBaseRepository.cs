using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTRPZ4.Infrastructure.Repository.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task InsertAsync(TEntity entity);
        void Update(TEntity? entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> GetById(int? id);
    }
}
