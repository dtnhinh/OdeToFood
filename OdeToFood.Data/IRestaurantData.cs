using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsBuyName(string name);
        Restaurant GetById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Pita Bread", Location = "Bolywood", Cuisine = CuisineType.Indian},
                new Restaurant {Id = 2, Name = "Spaghetty", Location = "Vien", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 3, Name = "Fajitas", Location = "San Juan", Cuisine = CuisineType.Mexican},
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsBuyName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
