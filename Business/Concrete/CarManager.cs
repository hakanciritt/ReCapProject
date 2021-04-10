using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        private ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.Id == carId));
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.ColorId == colorId));
        }
        public IDataResult<List<CarDetailDto>> GetByColorAndBrand(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>
                (_carDal.GetCarDetails(x => x.BrandId == brandId || x.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.CarDetails());
        }

        public IDataResult<CarDetailDto> GetByIdCarDetails(int id)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetail(x => x.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsBrandName(string brandName)
        {
            return new SuccessDataResult<List<CarDetailDto>>
                (_carDal.GetCarDetails(x => x.BrandName == brandName));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsColorName(string colorName)
        {
            return new SuccessDataResult<List<CarDetailDto>>
                (_carDal.GetCarDetails(x => x.ColorName == colorName));
        }
       
    }
}
