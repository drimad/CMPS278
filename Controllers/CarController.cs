using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers;

[ApiController]
[Route("/api/")]
public class CarController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllCars()
    {
        // return Ok("list of cars");
        return NotFound();
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOneCar(int id)
    {
        return Ok("good job");
    }

    [HttpPost]
    public IActionResult AddCar(string car)
    {
        return Ok("car added");
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteCar(int id)
    {
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateCar(int id, string car)
    {
        return NoContent();
    }


}
