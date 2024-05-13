using MTRPZ4.Models;

namespace MTRPZ4.Repository.IRepository;

public interface IDeviceRepository
{
    Task<Device> GetByToken(string token);
    Task<IEnumerable<Device>> GetAll();
    Task Add(Device device);
    Task Update(Device device);
}