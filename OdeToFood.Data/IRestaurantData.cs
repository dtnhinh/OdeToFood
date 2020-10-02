using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Hanoi", Location = "Vietnam", Cuisine = CuisineType.Indian},
                new Restaurant {Id = 2, Name = "HCM", Location = "Indochina", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 3, Name = "Thaibinh", Location = "Asia", Cuisine = CuisineType.Mexican},
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
