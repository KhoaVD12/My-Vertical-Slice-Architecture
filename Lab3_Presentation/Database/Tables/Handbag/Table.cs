using System.ComponentModel.DataAnnotations;

namespace Lab3_Presentation.Database.Tables.Handbag;

public class Table
{
    [Key]
    public int HandbagID { get; set; }
    public int BrandID { get; set; }
    public string ModelName { get; set; } = string.Empty;
    public string Material { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateOnly ReleaseDate { get; set; }
}
