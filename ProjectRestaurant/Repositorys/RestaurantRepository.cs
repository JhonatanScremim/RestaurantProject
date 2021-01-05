using ProjectRestaurant.Controllers.Inputs;
using ProjectRestaurant.Domains.Entities;
using ProjectRestaurant.Domains.Enums;
using ProjectRestaurant.Domains.ValueObjects;
using ProjectRestaurant.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurant.Repositorys
{
    public class RestaurantRepository : IRestaurantRepository
    {
        public Restaurant PostRestaurant(RestaurantInput restaurant, Kitchen kitchen)
        {
            var newRestaurant = new Restaurant(restaurant.RestaurantName, kitchen);
            var address = new Address(
                restaurant.Street,
                restaurant.Number,
                restaurant.City,
                restaurant.UF,
                restaurant.Cep);
            newRestaurant.AddAddress(address);
            return newRestaurant;
        }
    }
}
