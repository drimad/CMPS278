using Cars.Data;
using Cars.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.Repos;

public class CarRepo
{
    private readonly AppDbContext _db;

    public CarRepo(AppDbContext db)
    {
        this._db = db;
    }

    public void AddCarAsync(Car car)
    {
        _db.Cars.Add(car);
        var count = _db.SaveChanges();
        if (count == 0)
            throw new Exception("Failed");
    }

    public async Task DeleteCarAsync(int id)
    {
        _db.Cars.Remove(await this.GetCarAsync(id));
        if (await _db.SaveChangesAsync() == 0)
            throw new Exception("Failed");
    }

    public async Task UpdateCarAsync(int id, Car car)
    {
        var carToBeUpdated = await GetCarAsync(id);
        if (carToBeUpdated == null)
            throw new Exception("Failed");
        carToBeUpdated.Brand = car.Brand;
        carToBeUpdated.Color = car.Color;
        carToBeUpdated.NumberOfDoors = car.NumberOfDoors;
        carToBeUpdated.Year = car.Year;
        if (await _db.SaveChangesAsync() == 0)
            throw new Exception("Failed");
    }

    public async Task<Car?> GetCarAsync(int id)
    {
        return await _db.Cars.FirstOrDefaultAsync(x => x.Id == id); // LINQ query
    }

    public async Task<IEnumerable<Car>> GetCarsSync()
    {
        return await _db.Cars.ToListAsync();
    }

}