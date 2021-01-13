using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProjectRestaurant.Domains.Entities;
using ProjectRestaurant.Domains.Enums;
using ProjectRestaurant.Domains.ValueObjects;

namespace ProjectRestaurant.Data.Schemas
{
    public class RestaurantSchema
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public Kitchen Kitchen { get; set; }
        public AddressSchema Address { get; set; }
    }

    public static class RestauranSchemaExtension
    {
        public static Restaurant ConvertToDomain(this RestaurantSchema restaurantSchema)
        {
            var restaurant = new Restaurant(restaurantSchema.Id.ToString(), restaurantSchema.Name, restaurantSchema.Kitchen);
            var address = new Address(restaurantSchema.Address.Street, restaurantSchema.Address.Number, restaurantSchema.Address.City, restaurantSchema.Address.UF, restaurantSchema.Address.Cep);
            restaurant.AddAddress(address);
            return restaurant;
        }
    }
}
