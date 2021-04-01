using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator :AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(x => x.RentDate).NotEmpty().WithMessage("Kiralama tarihi boş geçilemez");
            RuleFor(x => x.ReturnDate).NotEmpty().WithMessage("İade tarihi boş geçilemez");
            RuleFor(x => x.CarId).GreaterThan(0).NotEmpty();
        }
    }
}
