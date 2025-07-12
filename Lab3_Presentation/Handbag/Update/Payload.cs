namespace Lab3_Presentation.Handbag.Update;

public class Payload
{
    public int HandbagId { get; set; }
    public string? ModelName { get; set; } 
    public string? Material { get; set; }
    public decimal? Price { get; set; }
    public int? Stock { get; set; }
    public int? BrandId { get; set; }
}
