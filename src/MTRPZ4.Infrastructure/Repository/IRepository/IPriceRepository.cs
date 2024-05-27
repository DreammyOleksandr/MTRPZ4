using MTRPZ4.CoreDomain.Entities;

namespace MTRPZ4.Infrastructure.Repository.IRepository;

public interface IPriceRepository
{
    Task<Price> GetById(int? id);
    Task<List<Price>> GetAll();
}