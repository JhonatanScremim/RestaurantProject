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
        Task<IEnumerable<Restaurant>> GetAll();
        Restaurant GetById(string id);
        Restaurant PostRestaurant(RestaurantInput restaurant);
        bool PutRestaurant(PutRestaurantInput body);
        bool UpdateKitchen(string id, int kitchen);
    }
}
