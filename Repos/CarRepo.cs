using Cars.Models;

namespace Cars.Repos;
public class CarRepo
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
}