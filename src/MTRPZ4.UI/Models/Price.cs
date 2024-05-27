using System.ComponentModel.DataAnnotations;

namespace MTRPZ4.UI.Models;

public class Price
{
    [Key] public int Id { get; set; }
    public decimal Value { get; set; }
}