using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurant.Domains.ValueObjects
{
    public class Address : AbstractValidator<Address>
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string Cep { get; set; }

        public Address(string street, string number, string city, string uF, string cep)
        {
            Street = street;
            Number = number;
            City = city;
            UF = uF;
            Cep = cep;
        }
        public ValidationResult ValidationResult { get; set; }

        public bool Validation()
        {
            ValidateElements();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        private void ValidateElements()
        {
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("A rua não pode ser vazia.")
                .MaximumLength(50).WithMessage("Rua pode ter no máximo 50 caracteres.");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("A cidade não pode ser vazia.")
                .MaximumLength(100).WithMessage("Cidade pode ter no máximo 100 caracteres.");
            RuleFor(x => x.UF)
                .NotEmpty().WithMessage("UF não pode ser vazio.")
                .MaximumLength(2).WithMessage("UF pode ter no máximo 2 caracteres.");
            RuleFor(x => x.Cep)
                .NotEmpty().WithMessage("O CEP não pode ser vazio.")
                .MaximumLength(8).WithMessage("Cep pode ter no máximo 8 caracteres.");
        }

        //private void ValidateStreet()
        //{
        //    RuleFor(x => x.Street)
        //        .NotEmpty().WithMessage("A rua não pode ser vazia.")
        //        .MaximumLength(50).WithMessage("Rua pode ter no máximo 50 caracteres.");
        //}

        //private void ValidateCity()
        //{
        //    RuleFor(x => x.City)
        //        .NotEmpty().WithMessage("A cidade não pode ser vazia.")
        //        .MaximumLength(100).WithMessage("Cidade pode ter no máximo 100 caracteres.");
        //}

        //private void ValidateUf()
        //{
        //    RuleFor(x => x.UF)
        //        .NotEmpty().WithMessage("UF não pode ser vazio.")
        //        .MaximumLength(2).WithMessage("UF pode ter no máximo 2 caracteres.");
        //}

        //private void ValidateCep()
        //{
        //    RuleFor(x => x.Cep)
        //        .NotEmpty().WithMessage("O CEP não pode ser vazio.")
        //        .MaximumLength(8).WithMessage("Cep pode ter no máximo 8 caracteres.");
        //}
    }
}
