using MTRPZ4.UI.Models;

namespace MTRPZ4.Repository.IRepository;

public interface IButtonColorRepository
{
    Task<ButtonColor> GetById(int? id);
    Task<List<ButtonColor>> GetAll();
}