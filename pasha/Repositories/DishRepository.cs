using pasha.Models;

namespace pasha.Repositories;

public class DishRepository
{
    public static List<Dish> Dishes = new List<Dish>()
    {
        new Dish() {Description = "pretty good food", Id = 1, Rating = 5.5, Title = "dish1"}
    };
}