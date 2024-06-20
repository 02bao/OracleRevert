using Microsoft.EntityFrameworkCore;
using OracleRevert.Entity;

namespace OracleRevert.Data;

public class DataContext : DbContext
{
   public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<CSB_Revert> Reverts { get; set; }

    public static string configsql = "Host=localhost:5432;Database=OracleRevert;Username=postgres;Password=postgres";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(configsql);
        optionsBuilder.EnableSensitiveDataLogging();
    }
}
