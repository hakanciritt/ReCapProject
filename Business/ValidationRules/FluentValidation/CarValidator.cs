using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.DailyPrice).GreaterThan(0);
            RuleFor(x => x.BrandId).NotEmpty().WithMessage("Marka alanı boş geçilemez");
            RuleFor(x => x.ColorId).NotEmpty().WithMessage("Renk alanı boş geçilemez");
            RuleFor(x => x.ModelYear).NotEmpty().WithMessage("Model yılı boş geçilemez");
            RuleFor(x => x.Description).MinimumLength(20).WithMessage("En az 20 karakter uzunluğunda olmalıdır");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez");
        }
    }
}
