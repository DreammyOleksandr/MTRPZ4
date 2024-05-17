using MTRPZ4.Models;

namespace MTRPZ4;

public interface IDataStorage
{
    List<Device> GetDevices();
    List<Price> GetPrices();
    List<ButtonColor> GetButtonColors();
}