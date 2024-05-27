using MTRPZ4.Application.Models;
using MTRPZ4.CoreDomain.Entities;

namespace MTRPZ4.Infrastructure.DataStorage;

public sealed class DataStorage : IDataStorage
{
    public List<Device> Devices = new();
    public readonly List<Color> ButtonColors = new()
    {
        new Color { Id = 1, Pigment = "#FF0000", },
        new Color { Id = 2, Pigment = "#00FF00", },
        new Color { Id = 3, Pigment = "#0000FF", }
    };

    public readonly List<Price> Prices = new()
    {
        new Price { Id = 1, Value = 10M, },
        new Price { Id = 2, Value = 20M, },
        new Price { Id = 3, Value = 50M, },
        new Price  {Id = 4, Value = 5M, }
    };
    
    public List<Device> GetDevices() => Devices;
    public List<Price> GetPrices() => Prices;
    public List<Color> GetButtonColors() => ButtonColors;
}