namespace Lab3_Presentation.Handbag.All;

public class Parameters
{
    public int? HandbagID { get; set; }
    public int? BrandID { get; set; }
    public string? ModelName { get; set; }
    public string? Material { get; set; } 
    public string? Color { get; set; } 
    public decimal? Price { get; set; }
    public int? Stock { get; set; }
    public DateOnly FromDate { get; set; }
    public DateOnly ToDate { get; set; }
}
