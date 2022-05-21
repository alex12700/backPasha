using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pasha.Models;
using pasha.Services;

namespace pasha.Controllers;

[ApiController]
[Route("/dish")]
public class DishController : Controller
{
    private readonly IDishService _dishService;

    public DishController(IDishService dishService)
    {
        _dishService = dishService;
    }

    [HttpPost]
    [Route("create")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    public Dish Create([FromBody] Dish newDish)
    {
        return _dishService.Create(newDish);
    }
    
    [HttpGet]
    [Route("get/{id:int:min(1)}")]
    public Dish Get(int id)
    {
        return _dishService.Get(id);
    }
    
    [HttpGet]
    [Route("get")]
    public List<Dish> Get()
    {
        return _dishService.GetAll();
    }

    [HttpPut]
    [Route("update")]
    public Dish Update([FromBody]Dish newDish)
    {
        return _dishService.Update(newDish);
    }

    [HttpDelete]
    [Route("delete/{id:int:min(1)}")]
    public bool Delete(int id)
    {
        return _dishService.Delete(id);
    }
}