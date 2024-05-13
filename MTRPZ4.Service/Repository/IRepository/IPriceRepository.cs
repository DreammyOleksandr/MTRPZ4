using MTRPZ4.Models;

namespace MTRPZ4.Repository.IRepository;

public interface IPriceRepository
{
    Task<Price> GetById(int? id);
    Task<IEnumerable<Price>> GetAll();
}