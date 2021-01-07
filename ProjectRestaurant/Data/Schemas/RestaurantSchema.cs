using ProjectRestaurant.Domains.Enums;

namespace ProjectRestaurant.Data.Schemas
{
    public class RestaurantSchema
    {
        public string RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public Kitchen Kitchen { get; set; }
        public AddressSchema Address { get; set; }
    }
}
