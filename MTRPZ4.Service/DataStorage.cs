using ABPBackendTZ.Models;

namespace ABPBackendTZ;

public sealed class DataStorage
{
    public List<Device> Devices = new();
    public readonly List<ButtonColor> ButtonColors = new()
    {
        new ButtonColor
        {
            Id = 1,
            HEX = "#FF0000",
        },
        new ButtonColor
        {
            Id = 2,
            HEX = "#00FF00",
        },
        new ButtonColor
        {
            Id = 3,
            HEX = "#0000FF",
        }
    };

    public readonly List<Price> Prices = new()
    {
        new Price
        {
            Id = 1,
            Value = 10M,
        },
        new Price
        {
            Id = 2,
            Value = 20M,
        },
        new Price
        {
            Id = 3,
            Value = 50M,
        },
        new Price
        {
            Id = 4,
            Value = 5M,
        }
    };
}