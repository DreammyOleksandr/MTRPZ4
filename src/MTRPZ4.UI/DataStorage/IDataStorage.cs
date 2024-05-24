using MTRPZ4.Infrastructure.DataStorage;
using MTRPZ4.UI.Models;

namespace MTRPZ4.Infrastructure.DataStorage;

public interface IDataStorage
{
    List<Device> GetDevices();
    List<Price> GetPrices();
    List<ButtonColor> GetButtonColors();
}