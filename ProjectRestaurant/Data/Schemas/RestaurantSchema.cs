using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProjectRestaurant.Domains.Enums;

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
}
