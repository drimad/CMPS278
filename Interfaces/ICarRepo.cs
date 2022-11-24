using Cars.Models;

namespace Cars.Interfaces;

public interface ICarRepo
{
    Task<List<Car>> GetCarsAsync();
    Task<Car?> GetByIdAsync(int id);
    Task<Car?> AddCarAsync(Car car);
    Task<bool> DeleteCarAsync(int id);
    Task<Car?> UpdateCarAsync(Car car, int id);
}