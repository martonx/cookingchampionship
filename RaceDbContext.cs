using Microsoft.EntityFrameworkCore;

namespace CookingChampionship;

public class RaceDbContext : DbContext
{
    public DbSet<Team> Teams { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CookResult> CookResults { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=CookingChampionship;Integrated Security=true");
}
