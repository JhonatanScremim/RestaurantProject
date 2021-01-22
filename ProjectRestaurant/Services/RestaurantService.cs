using ProjectRestaurant.Controllers.Inputs;
using ProjectRestaurant.Data.Schemas;
using ProjectRestaurant.Domains.Entities;
using ProjectRestaurant.Domains.ValueObjects;
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
        public Task<IEnumerable<Restaurant>> GetAll()
        {
            return _repository.GetAll();
        }

        public Restaurant GetById(string id)
        {
            var result = _repository.GetById(id);
            if (result == null)
                return null;

            return result.ConvertToDomain();
        }

        public bool PutRestaurant(PutRestaurantInput body)
        {
            var restaurant = _repository.GetById(body.RestaurantId);

            if (restaurant == null)
                return false;

            var kitchen = KitchenHelper.ConvertToInteger(body.Kitchen);

            var newRestaurant = new Restaurant(body.RestaurantId, body.RestaurantName, kitchen);
            var address = new Address(
                body.Street,
                body.Number,
                body.City,
                body.UF,
                body.Cep);

            newRestaurant.AddAddress(address);
            if (!newRestaurant.Validation())
                return false;

            if (!_repository.PutRestaurant(newRestaurant))
                return false;

            return true;
        }

        public bool UpdateKitchen(string id, int kitchen)
        {
            var restaurant = _repository.GetById(id);

            if (restaurant == null)
                return false;

            var newKitchen = KitchenHelper.ConvertToInteger(kitchen);

            if (!_repository.UpdateKitchen(id, newKitchen))
                return false;

            return true;
        }
    }
}
