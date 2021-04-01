using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<CarDetailDto> GetByIdCarDetails(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsBrandName(string brandName);
        IDataResult<List<CarDetailDto>> GetCarDetailsColorName(string colorName);
        IDataResult<List<CarDetailDto>> GetByColorAndBrand(int brandId, int colorId);
    }
}
