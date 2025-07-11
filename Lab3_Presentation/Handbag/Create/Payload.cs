using System.ComponentModel.DataAnnotations;

namespace Lab3_Presentation.Handbag.Create;

public class Payload
{
    [Required]
    public string ModelName { get; set; }=string.Empty;
    [Required]
    public string Material { get; set; }=string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int BrandId { get; set; }
}
