using MTRPZ4.Models;

namespace MTRPZ4.Repository.IRepository;

public interface IButtonColorRepository
{
    Task<ButtonColor> GetById(int? id);
    Task<IEnumerable<ButtonColor>> GetAll();
}