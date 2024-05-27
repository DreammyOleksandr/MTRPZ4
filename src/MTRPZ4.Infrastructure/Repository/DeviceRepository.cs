using MTRPZ4.Application.Models;
using MTRPZ4.Infrastructure.DataStorage;
using MTRPZ4.Infrastructure.Repository.IRepository;

namespace MTRPZ4.Infrastructure.Repository;

public class DeviceRepository : IDeviceRepository
{
    private readonly IDataStorage _data;

    public DeviceRepository(IDataStorage data)
    {
        _data = data;
    }

    public async Task<Device> GetByToken(string token) => _data.GetDevices().Find(x => string.Equals(x.Token, token));
    public async Task<List<Device>> GetAll() => _data.GetDevices();
    public async Task Add(Device device) => _data.GetDevices().Add(device);
    public async Task Update(Device device)
    {
        var result = _data.GetDevices().FirstOrDefault(x => x.Token == device.Token);
        if (result is { })
        {
            result = device;
        }
    }
}