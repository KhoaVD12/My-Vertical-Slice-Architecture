namespace Lab3_Presentation.Handbag.Update;

public class Payload
{
    public string ModelName { get; set; } = string.Empty;
    public string Material { get; set; } = string.Empty;
    public decimal? Price { get; set; }
    public int? Stock { get; set; }
    public int? BrandId { get; set; }
}
