using MTRPZ4.CoreDomain.Entities;

namespace MTRPZ4.Infrastructure.Repository.IRepository;

public interface IButtonColorRepository
{
    Task<ButtonColor> GetById(int? id);
    Task<List<ButtonColor>> GetAll();
}