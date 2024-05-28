using MTRPZ4.CoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTRPZ4.Infrastructure.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Color> Colors { get; }
        IBaseRepository<Font> Fonts { get; }
        IBaseRepository<Price> Prices { get; }
        void SaveChanges();
        Task SaveChangesAsync();

    }
}
