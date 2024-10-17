using Microsoft.EntityFrameworkCore;

namespace CookingChampionship;

public class RaceDbContext : DbContext
{
    public DbSet<Team> Teams { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CookResult> CookResults { get; set; }

    private readonly string DbPath;

    public RaceDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "CookingChampionship.db");
    }

    // For local Sql Server
    //protected override void OnConfiguring(DbContextOptionsBuilder options)
    //    => options.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=CookingChampionship;Integrated Security=true");

    // For SqlLite database
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
