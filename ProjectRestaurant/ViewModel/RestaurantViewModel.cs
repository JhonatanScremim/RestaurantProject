using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurant.ViewModel
{
    public class RestaurantViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Kitchen { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
