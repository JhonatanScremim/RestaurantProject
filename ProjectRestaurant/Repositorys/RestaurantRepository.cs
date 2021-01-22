using MongoDB.Driver;
using ProjectRestaurant.Controllers.Inputs;
using ProjectRestaurant.Data;
using ProjectRestaurant.Data.Schemas;
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
        IMongoCollection<RestaurantSchema> _restaurant;

        public RestaurantRepository(ProjectRestaurant.Data.MongoDB mongoDB)
        {
            _restaurant = mongoDB.database.GetCollection<RestaurantSchema>("Restaurant");
        }

        public async Task<IEnumerable<Restaurant>> GetAll()
        {
            var listRestaurants = new List<Restaurant>();

            await _restaurant.AsQueryable().ForEachAsync(d =>
            {
                var restaurant = new Restaurant(d.Id.ToString(), d.Name, d.Kitchen);
                var address = new Address(d.Address.Street, d.Address.Number, d.Address.City, d.Address.UF, d.Address.Cep);
                restaurant.AddAddress(address);
                listRestaurants.Add(restaurant);
            });
            return listRestaurants;
        }

        public RestaurantSchema GetById(string id)
        {
            return _restaurant.AsQueryable().FirstOrDefault(x => x.Id == id);
        }
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
            InsertRestaurant(newRestaurant);
            return newRestaurant;
        }

        public void InsertRestaurant(Restaurant restaurant)
        {
            var document = new RestaurantSchema
            {
                Name = restaurant.RestaurantName,
                Kitchen = restaurant.Kitchen,
                Address = new AddressSchema
                {
                    Street = restaurant.Address.Street,
                    Number = restaurant.Address.Number,
                    City = restaurant.Address.City,
                    UF = restaurant.Address.UF,
                    Cep = restaurant.Address.Cep,
                }
            };

            _restaurant.InsertOne(document);
        }

        public bool PutRestaurant(Restaurant restaurant)
        {
            var document = new RestaurantSchema
            {
                Id = restaurant.RestaurantId,
                Name = restaurant.RestaurantName,
                Kitchen = restaurant.Kitchen,
                Address = new AddressSchema
                {
                    Street = restaurant.Address.Street,
                    Number = restaurant.Address.Number,
                    City = restaurant.Address.City,
                    UF = restaurant.Address.UF,
                    Cep = restaurant.Address.Cep
                }
            };

            var result = _restaurant.ReplaceOne(x => x.Id == document.Id, document);

            return result.ModifiedCount > 0;
        }

        public bool UpdateKitchen(string id, Kitchen kitchen)
        {
            var update = Builders<RestaurantSchema>.Update.Set(x => x.Kitchen, kitchen);

            var result = _restaurant.UpdateOne(x => x.Id == id, update);

            return result.ModifiedCount > 0;
        }

        public bool UpdateName(string id, string name)
        {
            var update = Builders<RestaurantSchema>.Update.Set(x => x.Name, name);

            var result = _restaurant.UpdateOne(x => x.Id == id, update);

            return result.ModifiedCount > 0;
        }
    }
}
