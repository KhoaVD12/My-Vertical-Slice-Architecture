using System.ComponentModel.DataAnnotations;
namespace Lab3_Presentation.Database.Tables.Brand;

public class Table
{
    [Key]
    public int BrandID { get; set; }
    public string BrandName { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public int FoundedYear { get; set; }
    public string Website { get; set; } = string.Empty;
}
