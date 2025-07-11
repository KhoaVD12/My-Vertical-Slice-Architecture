using Microsoft.EntityFrameworkCore;

namespace Lab3_Presentation.Database;

public class Context:DbContext
{
    public Context(DbContextOptions<Context> options): base(options)
    {
        
    }
    public DbSet<Tables.SystemAccount.Table> SystemAccounts { get; set; }
    public DbSet<Tables.Handbag.Table> Handbag { get; set; }
    public DbSet<Tables.Brand.Table> Brand { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
