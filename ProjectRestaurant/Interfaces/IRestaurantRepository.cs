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
        Restaurant PostRestaurant(RestaurantInput restaurant, Kitchen kitchen);
        Task<IEnumerable<Restaurant>> GetAll();
        RestaurantSchema GetById(string id);
    }
}
