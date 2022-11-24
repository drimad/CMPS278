using Cars.Data;
using Cars.Interfaces;
using Cars.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.Repos;

public class CarRepo : ICarRepo
{
    private readonly AppDbContext _db;

    public CarRepo(AppDbContext db)
    {
        this._db = db;
    }

    public async Task<Car?> AddCarAsync(Car car)
    {
        _db.Cars.Add(car);
        var success = await _db.SaveChangesAsync() > 0;
        if (!success)
            return null;
        return car;
    }

    public async Task<bool> DeleteCarAsync(int id)
    {
        var car = await _db.Cars.FirstOrDefaultAsync(x => x.Id == id);
        if (car == null)
            return false;
        _db.Cars.Remove(car);
        var success = await _db.SaveChangesAsync() > 0;
        if (!success)
            return false;
        return true;
    }

    public async Task<Car?> GetByIdAsync(int id)
    {
        var car = await _db.Cars.FirstOrDefaultAsync(x => x.Id == id);
        if (car != null)
            return car;
        return null;
    }

    public async Task<List<Car>> GetCarsAsync()
    {
        return await _db.Cars.ToListAsync();
    }

    public async Task<Car?> UpdateCarAsync(Car car, int id)
    {
        var carToBeUpdated = await GetByIdAsync(id);
        if (carToBeUpdated == null) return null;

        carToBeUpdated.Brand = car.Brand;
        carToBeUpdated.Color = car.Color;
        carToBeUpdated.NumberOfDoors = car.NumberOfDoors;
        carToBeUpdated.Year = car.Year;

        return carToBeUpdated;
    }
}