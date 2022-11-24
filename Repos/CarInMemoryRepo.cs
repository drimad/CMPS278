using Cars.Interfaces;
using Cars.Models;

namespace Cars.Repos;
public class CarInMemoryRepo : ICarRepo
{
    private List<Car> Cars = new List<Car>
    {
        new Car(){
            Id=1,
            Brand="BMW",
            Color="Black",
            Year=2020
        },
        new Car(){
            Id=2,
            Brand="Toyota",
            Color="Rav4",
            Year=2022
        }
    };

    public void AddCar(Car car)
    {
        this.Cars.Add(car);
    }

    public void DeleteCar(int id)
    {
        // delete the car
    }

    public void UpdateCar(int t, Car car)
    {
        //update the car
    }

    public Car GetCar(int id)
    {
        return Cars[id];
    }

    public List<Car> GetCars()
    {
        return Cars;
    }

    public Task<List<Car>> GetCarsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Car?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Car?> AddCarAsync(Car car)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteCarAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Car?> UpdateCarAsync(Car car, int id)
    {
        throw new NotImplementedException();
    }
}