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
                RestaurantName = restaurant.RestaurantName,
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
    }
}
