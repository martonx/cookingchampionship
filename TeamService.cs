using Microsoft.EntityFrameworkCore;

namespace CookingChampionship;

public class TeamService
{
    private readonly RaceDbContext db;

    public TeamService()
    {
        db = new RaceDbContext();
    }

    public async Task CreateAsync()
    {
        var newTeam = new Team();
        Console.WriteLine("Add meg az új csapat nevét");
        newTeam.Name = Console.ReadLine();
        db.Teams.Add(newTeam);

        await db.SaveChangesAsync();
    }

    public async Task UpdateAsync()
    {
        await ListAllAsync();
        Console.WriteLine("Kérem válasszon Id-t, hogy melyik csapatot szeretné updatelni");
        var teamId = int.Parse(Console.ReadLine());
        Console.WriteLine("Kérem válasszon Id-t, hogy melyik kategóriában szeretné updatelni");
        var categoryId = int.Parse(Console.ReadLine());
        Console.WriteLine("Kérem adja meg az új pontszámot");
        var points = int.Parse(Console.ReadLine());

        var currentResult = db.CookResults.SingleOrDefault(result => result.TeamId == teamId && result.CategoryId == categoryId);
        if (currentResult is null)
        {
            currentResult = new CookResult
            {
                TeamId = teamId,
                CategoryId = categoryId,
                Points = points
            };

            db.CookResults.Add(currentResult);
        }
        else
        {
            currentResult.Points = points;
        }

        await db.SaveChangesAsync();
    }

    public async Task DeleteAsync()
    {
        await ListAllAsync();
        Console.WriteLine("Kérem válasszon Id-t, hogy melyik csapatot szeretné törölni");
        var teamId = int.Parse(Console.ReadLine());
        var teamForDelete = db.Teams.SingleOrDefault(t => t.Id == teamId);

        if (teamForDelete is null)
        {
            Console.WriteLine("Ne legyél hülye!");
            return;
        }

        if (teamForDelete.Results.Any())
        {
            Console.WriteLine("A csapat nem törölhető, mert már van verseny eredménye");
            return;
        }

        db.Teams.Remove(teamForDelete);
        await db.SaveChangesAsync();
    }

    public async Task ListAllAsync()
    {
        var teams = await db.Teams
                        .Include(t => t.Results)
                            .ThenInclude(r => r.Category)
                        .ToListAsync();

        Console.WriteLine("Összes csapat");
        foreach (var team in teams)
        {
            Console.WriteLine($"Id: {team.Id} Név: {team.Name}");
            Console.WriteLine("Kategóriái");
            foreach (var result in team.Results)
                Console.WriteLine($"Kategória: {result.Category.Name} Pontszám: {result.Points}");
        }

        Console.WriteLine("Összes kategória");
        foreach (var category in await db.Categories.ToListAsync())
            Console.WriteLine($"Id: {category.Id} Név: {category.Name}");
    }
}
