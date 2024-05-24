using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTRPZ4.UI.Models;

public class Device
{
    [Key] public string Token { get; set; }
    public int? ButtonColorId { get; set; }
    [ForeignKey("ButtonColorId")]
    public ButtonColor? ButtonColor { get; set; }
    public int? PriceId { get; set; }
    [ForeignKey("PriceId")]
    public Price? Price { get; set; }
}