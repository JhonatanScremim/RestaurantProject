using ProjectRestaurant.Controllers.Inputs;
using ProjectRestaurant.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurant.Interfaces
{
    public interface IRestaurantService
    {
        Restaurant PostRestaurant(RestaurantInput restaurant);
        Task<IEnumerable<Restaurant>> GetAll();
    }
}
