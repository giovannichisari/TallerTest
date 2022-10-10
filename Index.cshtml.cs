using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        public List<Car> gCars;

        public IndexModel()
        {
            gCars = new List<Car>();

            Create(new Car { Id = 1, Make = "Audi", Model = "R8", Year = 2018, Doors = 2, Color = "Red", Price = 79995 });
            Create(new Car { Id = 2, Make = "Tesla", Model = "3", Year = 2018, Doors = 4, Color = "Black", Price = 54995 });
            Create(new Car { Id = 3, Make = "Porsche", Model = "911991", Year = 2020, Doors = 2, Color = "White", Price = 155000 });
            Create(new Car { Id = 4, Make = "Mercedes-Benz", Model = "GLE 635", Year = 2021, Doors = 5, Color = "Blue", Price = 83995 });
            Create(new Car { Id = 5, Make = "BMW", Model = "XM 6", Year = 2020, Doors = 5, Color = "Silver", Price = 62995 });
        }

        void Create(Car pCar)
        {
            if (gCars.FirstOrDefault(c => c.Id == pCar.Id) != null)
                Update(pCar);

            gCars.Add(pCar);
        }

        void Update(Car pCar)
        {
            Car lCar = gCars.FirstOrDefault(c => c.Id == pCar.Id);

            if (lCar != null)
            {
                lCar.Make = pCar.Make;
                lCar.Model = pCar.Model;
                lCar.Year = pCar.Year;
                lCar.Doors = pCar.Doors;
                lCar.Color = pCar.Color;
                lCar.Price = pCar.Price;
            }
            else
                Create(pCar);
        }

        void Delete(int pId)
        {
            gCars.RemoveAll(c => c.Id == pId);
        }

        public void OnPostGuess(int pCarId, int pGuessValue)
        {
            Car lCar = gCars.FirstOrDefault(c => c.Id == pCarId);

            if (Enumerable.Range(lCar.Price - 5000, lCar.Price + 5000).Contains(pGuessValue)) 
            {
                lCar.Guessed = true;
            } 
        }

        public class Car
        {
            public int Id { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public int Doors { get; set; }
            public string Color { get; set; }
            public int Price { get; set; }
            public bool Guessed { get; set; }
        }

        public void OnGet()
        {
        }
    }
}
