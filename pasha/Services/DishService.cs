using pasha.Models;
using pasha.Repositories;

namespace pasha.Services;

public class DishService :IDishService
{
    public Dish Create(Dish dish)
    {
        dish.Id = DishRepository.Dishes.Count + 1;
        DishRepository.Dishes.Add(dish);
        return dish;
    }

    public Dish Get(int id)
    {
        return DishRepository.Dishes.FirstOrDefault(x => x.Id == id);
    }

    public List<Dish> GetAll()
    {
        return DishRepository.Dishes;
    }

    public Dish Update(Dish newDish)
    {
        var dish = DishRepository.Dishes.FirstOrDefault(x => x.Id == newDish.Id);
        dish.Description = newDish.Description;
        dish.Rating = newDish.Rating;
        dish.Title = newDish.Title;
        return dish;
    }

    public bool Delete(int id)
    {
        var dish = DishRepository.Dishes.FirstOrDefault(x => x.Id == id);
        return DishRepository.Dishes.Remove(dish);
    }
}