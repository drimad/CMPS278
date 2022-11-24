using Microsoft.AspNetCore.Mvc;
using Cars.Models;
using Cars.Repos;
using Cars.Interfaces;

namespace Cars.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarRepo _repo;

    public CarsController(ICarRepo repo)
    {
        this._repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<List<Car>>> GetAllCars()
    {
        return Ok(await _repo.GetCarsAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOneCar(int id)
    {
        var car = await _repo.GetByIdAsync(id);
        if (car == null)
            return NotFound();
        return Ok(car);
    }

    [HttpPost]
    public async Task<ActionResult<Car>> AddCar(Car car)
    {
        var addedCar = await _repo.AddCarAsync(car);
        if (addedCar != null) return
            Created($"api/cars/{addedCar.Id}", addedCar);
        return BadRequest();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        var success = await _repo.DeleteCarAsync(id);
        if (success)
            return NoContent();
        return BadRequest();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCar(int id, Car car)
    {
        var updatedCar = await _repo.UpdateCarAsync(car, id);
        if (updatedCar != null) return
            Ok(updatedCar);
        return BadRequest();
    }


}
