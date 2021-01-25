using ProjectRestaurant.Controllers.Inputs;
using ProjectRestaurant.Data.Schemas;
using ProjectRestaurant.Domains.Entities;
using ProjectRestaurant.Domains.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurant.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant>> GetAll();
        RestaurantSchema GetById(string id);
        IEnumerable<Restaurant> GetByName(string name);
        Restaurant PostRestaurant(RestaurantInput restaurant, Kitchen kitchen);
        bool PutRestaurant(Restaurant restaurant);
        bool UpdateKitchen(string id, Kitchen kitchen);
        bool UpdateName(string id, string name);
    }
}
