using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectRestaurant.Domains.Enums;

namespace ProjectRestaurant.Helpers
{
    public static class KitchenHelper
    {
        public static Kitchen ConvertToInteger(int value)
        {
            if (Enum.TryParse(value.ToString(), out Kitchen kitchen))
                return kitchen;

            throw new ArgumentOutOfRangeException("Falha na conversão de valores");
        }
    }
}
