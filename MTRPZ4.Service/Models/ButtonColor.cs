using System.ComponentModel.DataAnnotations;

namespace MTRPZ4.Models;

public class ButtonColor
{
    [Key] public int Id { get; set; }
    public string HEX { get; set; }
}