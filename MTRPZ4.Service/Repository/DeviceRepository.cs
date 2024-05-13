using ABPBackendTZ.Models;
using ABPBackendTZ.Repository.IRepository;

namespace ABPBackendTZ.Repository;

public class DeviceRepository : IDeviceRepository
{
    private readonly DataStorage _data;

    public async Task<Device> GetByToken(string token) => _data.Devices.Find(x => string.Equals(x.Token, token));
    public async Task<IEnumerable<Device>> GetAll() => _data.Devices;
    public async Task Add(Device device) => _data.Devices.Add(device);
    public async Task Update(Device device)
    {
        var result = _data.Devices.FirstOrDefault(x => x.Token == device.Token);
        if (result is {})
        {
            result = device;
        }
    }
}