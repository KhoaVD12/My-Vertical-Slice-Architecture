using System.ComponentModel.DataAnnotations;

namespace Lab3_Presentation.Database.Tables.SystemAccount;

public class Table
{
    [Key]
    public int AccountID { get; set; }
    public string Username { get; set; }=string.Empty;
    public string Email { get; set; }=string.Empty;
    public string Password { get; set; }=string.Empty;
    public int Role { get; set; }
    public bool IsActive { get; set; }
}
