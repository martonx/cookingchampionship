using Microsoft.EntityFrameworkCore;

namespace CookingChampionship;

[PrimaryKey(nameof(TeamId), nameof(CategoryId))]
public class CookResult
{
    public int TeamId { get; set; }
    public Team Team { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int Points { get; set; }
}
