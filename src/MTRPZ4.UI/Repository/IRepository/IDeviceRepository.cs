
using MTRPZ4.UI.Models;

namespace MTRPZ4.Repository.IRepository;

public interface IDeviceRepository
{
    Task<Device> GetByToken(string token);
    Task<List<Device>> GetAll();
    Task Add(Device device);
    Task Update(Device device);
}