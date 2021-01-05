using ProjectRestaurant.Controllers.Inputs;
using ProjectRestaurant.Domains.Entities;
using ProjectRestaurant.Helpers;
using ProjectRestaurant.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurant.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _repository;

        public RestaurantService(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        public Restaurant PostRestaurant(RestaurantInput restaurant)
        {
            var kitchen = KitchenHelper.ConvertToInteger(restaurant.Kitchen);

            var result = _repository.PostRestaurant(restaurant, kitchen);
            return result;
        }
    }
}
