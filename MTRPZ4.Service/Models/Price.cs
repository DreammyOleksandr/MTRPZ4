using System.ComponentModel.DataAnnotations;

namespace ABPBackendTZ.Models;

public class Price
{
    [Key] public int Id { get; set; }
    public decimal Value { get; set; }
}