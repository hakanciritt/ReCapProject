using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Minimum 3 karakter uzunluğunda olmalıdır");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Renk alanı boş geçilemez");
        }
    }
}
