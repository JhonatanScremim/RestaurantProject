using ProjectRestaurant.Domains.Enums;
using ProjectRestaurant.Domains.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
