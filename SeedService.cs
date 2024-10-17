namespace CookingChampionship;

public class SeedService
{
    private readonly RaceDbContext db;

    public SeedService()
    {
        db = new RaceDbContext();
    }

    public async Task SeedAsync()
    {
        for (int i = 0; i < 10; i++)
        {
            var team = new Team { Name = $"Csapat {i + 1}" };
            db.Teams.Add(team);
        }

        for (int i = 0; i < 3; i++)
        {
            var category = new Category { Name = $"Katgória {i + 1}" };
            db.Categories.Add(category);
        }

        await db.SaveChangesAsync();
    }
}
