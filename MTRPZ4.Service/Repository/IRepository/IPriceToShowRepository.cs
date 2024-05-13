using ABPBackendTZ.Models;

namespace ABPBackendTZ.Repository.IRepository;

public interface IPriceToShowRepository
{
    Task<Price> GetById(int? id);
    Task<IEnumerable<Price>> GetAll();
}