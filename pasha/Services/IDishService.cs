using pasha.Models;

namespace pasha.Services;

public interface IDishService
{
    public Dish Create(Dish dish);
    public Dish Get(int id);
    public List<Dish> GetAll();
    public Dish Update(Dish newDish);
    public bool Delete(int id);
}