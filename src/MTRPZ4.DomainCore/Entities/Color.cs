using System.ComponentModel.DataAnnotations;

namespace MTRPZ4.CoreDomain.Entities;

public class Color
{
    public int Id { get; set; }
    public string? HEX { get; set; }
}