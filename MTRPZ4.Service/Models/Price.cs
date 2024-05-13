using System.ComponentModel.DataAnnotations;

namespace MTRPZ4.Models;

public class Price
{
    [Key] public int Id { get; set; }
    public decimal Value { get; set; }
}