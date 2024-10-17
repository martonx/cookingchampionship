namespace CookingChampionship;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<CookResult> Results { get; set; } = new List<CookResult>();
}
