using System;
using System.Collections.Generic;
using System.IO;
namespace Car
{
    class Program
    {
        static List<Car> cars = new List<Car>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add car");
                Console.WriteLine("2. Search car");
                Console.WriteLine("3. Show all cars");
                Console.WriteLine("4. Exit");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddCar();
                        break;
                    case 2:
                        SearchCar();
                        break;
                    case 3:
                        ShowAllCars();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        static void AddCar()
        {
            Console.WriteLine("Enter car information:");
            Console.Write("Brand: ");
            string brand = Console.ReadLine();
            Console.Write("Model: ");
            string model = Console.ReadLine();
            Console.Write("Color: ");
            string color = Console.ReadLine();
            Console.Write("Number: ");
            string number = Console.ReadLine();

            Car car = new Car(brand, model, color, number);
            cars.Add(car);

            Console.WriteLine("Car added successfully.");
            SaveCars();
        }

        static void SearchCar()
        {
            Console.Write("Enter car number: ");
            string number = Console.ReadLine();

            Car car = cars.Find(c => c.Number == number);

            if (car == null)
            {
                Console.WriteLine("Car not found.");
            }
            else
            {
                Console.WriteLine("Car found:");
                car.GetCarInfo();
            }
        }

        static void ShowAllCars()
        {
            Console.WriteLine("All cars:");
            foreach (Car car in cars)
            {
                car.GetCarInfo();
            }
        }

        static void SaveCars()
        {
            using (StreamWriter writer = new StreamWriter("cars.txt"))
            {
                foreach (Car car in cars)
                {
                    writer.WriteLine($"{car.Brand},{car.Model},{car.Color},{car.Number}");
                }
            }
        }
    }
}