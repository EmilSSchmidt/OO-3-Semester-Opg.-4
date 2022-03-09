using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Obligatorisk_Opgave_3_semester;

namespace OO_3_Semester_Opg._4_version._2.Managers
{
    public class CarsManager
        {
            private static int _nextID = 1;
            //The 4 cars is only for testing purposes
            private static readonly List<Car> Data = new List<Car>
            {
                new Car(_nextID++,"BilModel1",1000, "AA12345"),
                new Car(_nextID++,"BilModel2",1500, "BB12345"),
                new Car(_nextID++,"BilModel3",2000, "CC12345"),
                new Car(_nextID++,"BilModel4",1000, "DD12345"),

            };

            public List<Car> GetAll(string substring = null, int maximumPrice = 2000)
            {
                List<Car> result = new List<Car>(Data);

                if (!string.IsNullOrEmpty(substring))
                {
                    result = Data.FindAll(car => car.Model.Contains(substring, StringComparison.OrdinalIgnoreCase));
                }

                if (maximumPrice != 0)
                {
                    result = result.FindAll(car => car.Price <= maximumPrice);
                }


                return result;

            }

            public Car GetById(int id)
            {
                return Data.Find(car => car.Id == id);
            }

            public Car AddCar(Car newCar)
            {
                newCar.Id = _nextID++;
                Data.Add(newCar);
                return newCar;
            }

            public Car Delete(int id)
            {
                Car car = Data.Find(car1 => car1.Id == id);
                if (car == null) return null;
                Data.Remove(car);
                return car;
            }

        }
    }


