using MTRPZ4.Application.Models;
using MTRPZ4.CoreDomain.Entities;
using MTRPZ4.Infrastructure.DataStorage;

namespace MTRPZ4.Infrastructure.DataStorage;

public interface IDataStorage
{
    List<Device> GetDevices();
    List<Price> GetPrices();
    List<ButtonColor> GetButtonColors();
}