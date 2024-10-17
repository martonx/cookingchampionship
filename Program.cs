using CookingChampionship;

var teamService = new TeamService();
while (true)
{
    Console.WriteLine("Mit szeretnél csinálni? 0 - Kilépés, 1 - Seed, 2 - Create Team, 3 - Update Team, 4 - Delete Team, 5 - List all teams, 6 - List best results");
    var input = Enum.Parse<MenuOption>(Console.ReadLine());

    switch (input)
    {
        case MenuOption.Exit:
            Environment.Exit(0);
            break;
        case MenuOption.Seed:
            var seedService = new SeedService();
            await seedService.SeedAsync();
            break;
        case MenuOption.CreateTeam:
            await teamService.CreateAsync();
            break;
        case MenuOption.UpdateTeam:
            await teamService.UpdateAsync();
            break;
        case MenuOption.DeleteTeam:
            await teamService.DeleteAsync();
            break;
        case MenuOption.ListAllTeams:
            await teamService.ListAllAsync();
            break;
        case MenuOption.ListBestResults:
            break;
    }
}