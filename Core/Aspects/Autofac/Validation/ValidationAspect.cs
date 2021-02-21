using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //eğer gönderilen validator type IValiadtory type değilse ona kız diyoruz burada
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }
            //eğer hata almaz isek gelen validatory tipi buraya ata 
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //reflection çalışma anında bir şeyleri çalıştırabilmemizi sağlar
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //validation type ın base tipi nin generic argümanlarından ilkini al dedik yani AbstractValidator<Product>
            //gibi burada ilk generic parametreyi aldık 
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //invocation metod demek metodun parametrelerine bak entity type denk gelen yani producta eşit olan parametreleri bul

            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //her birini tek tek gez validator toolu kullanarak validate et dedik.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
