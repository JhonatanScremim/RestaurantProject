using FluentValidation;
using FluentValidation.Results;
using ProjectRestaurant.Domains.Enums;
using ProjectRestaurant.Domains.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurant.Domains.Entities
{
    public class Restaurant : AbstractValidator<Restaurant>
    {
        public string RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public Kitchen Kitchen { get; set; }
        public Address Address { get; set; }

        public Restaurant(string restaurantId, string restaurantName, Kitchen kitchen)
        {
            RestaurantId = restaurantId;
            RestaurantName = restaurantName;
            Kitchen = kitchen;
        }

        public Restaurant(string restaurantName, Kitchen kitchen)
        {
            RestaurantName = restaurantName;
            Kitchen = kitchen;
        }


        public void AddAddress(Address address)
        {
            Address = address;
        }

        public ValidationResult ValidationResult { get; set; }

        public bool Validation()
        {
            ValidateName();
            ValidationResult = Validate(this); 

            ValidateAddress();
            return ValidationResult.IsValid;
        }

        private void ValidateName()
        {
            RuleFor(x => x.RestaurantName)
                .NotEmpty().WithMessage("O nome não pode ser vazio.")
                .MaximumLength(30).WithMessage("Nome pode ter no máximo 30 caracteres.");
        }

        private void ValidateAddress()
        {
            if (Address.Validation())
                return;

            foreach (var error in Address.ValidationResult.Errors)
                ValidationResult.Errors.Add(error);
        }
    }
}
