using System.ComponentModel.DataAnnotations;

namespace MTRPZ4.CoreDomain.Entities;

public class Price
{
    public int Id { get; set; }
    public decimal Value { get; set; }
}