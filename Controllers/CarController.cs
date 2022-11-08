using Microsoft.AspNetCore.Mvc;
using Cars.Models;
using Cars.Repos;

namespace Cars.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CarsController : ControllerBase
{

    [HttpGet]
    public IActionResult GetAllCars()
    {
        var repo = new CarRepo();
        return Ok(repo.GetCars());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOneCar(int id)
    {
        var repo = new CarRepo();
        return Ok(repo.GetCar(id));
    }

    [HttpPost]
    public IActionResult AddCar(Car car)
    {
        var repo = new CarRepo();
        repo.AddCar(car);
        return Created("", car);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteCar(int id)
    {
        var repo = new CarRepo();
        repo.DeleteCar(id);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateCar(int id, Car car)
    {
        var repo = new CarRepo();
        repo.UpdateCar(id, car);
        return NoContent();
    }


}
