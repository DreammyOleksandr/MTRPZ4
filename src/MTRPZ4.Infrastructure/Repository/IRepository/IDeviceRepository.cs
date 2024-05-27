using MTRPZ4.Application.Models;

namespace MTRPZ4.Infrastructure.Repository.IRepository;

public interface IDeviceRepository
{
    Task<Device> GetByToken(string token);
    Task<List<Device>> GetAll();
    Task Add(Device device);
    Task Update(Device device);
}