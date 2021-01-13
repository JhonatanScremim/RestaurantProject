using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurant.ViewModel
{
    public class AddressViewModel
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string Cep { get; set; }
    }
}
