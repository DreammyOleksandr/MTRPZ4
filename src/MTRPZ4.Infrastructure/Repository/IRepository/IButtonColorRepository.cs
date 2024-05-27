using MTRPZ4.CoreDomain.Entities;

namespace MTRPZ4.Infrastructure.Repository.IRepository;

public interface IButtonColorRepository
{
    Task<Color> GetById(int? id);
    Task<List<Color>> GetAll();
}