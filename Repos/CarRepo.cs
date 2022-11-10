using Cars.Data;
using Cars.Models;

namespace Cars.Repos;

public class CarRepo
{
    private readonly AppDbContext _db;

    public CarRepo(AppDbContext db)
    {
        this._db = db;
    }

    public void AddCar(Car car)
    {
    }

    public void DeleteCar(int id)
    {
    }

    public void UpdateCar(int t, Car car)
    {
    }

    public Car GetCar(int id)
    {
        var c = _db.Cars.Find(id); // LINQ query
        return c;

    }

    public List<Car> GetCars()
    {
        var cars = _db.Cars.ToList();
        return cars;
    }

}