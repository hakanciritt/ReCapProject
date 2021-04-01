using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> CarDetails()
        {
            using (CarContext context = new CarContext())
            {
                // CarName, BrandName, ColorName, DailyPrice
                var result = (from car in context.Cars.Cast<Car>()
                              join brand in context.Brands
                              on car.BrandId equals brand.Id
                              join col in context.Colors
                              on car.ColorId equals col.Id
                              join carImage in context.CarImages
                              on car.Id equals carImage.CarId
                              select new CarDetailDto
                              {
                                  Id = car.Id,
                                  CarName = car.CarName,
                                  BrandName = brand.Name,
                                  BrandId = brand.Id,
                                  ColorName = col.Name,
                                  ColorId = col.Id,
                                  DailyPrice = car.DailyPrice,
                                  ModelYear = car.ModelYear,
                                  Description = car.Description,
                                  ImagePath = carImage.ImagePath

                              }).ToList();

                return result;
            }

        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                // CarName, BrandName, ColorName, DailyPrice
                var result = (from car in context.Cars.Cast<Car>()
                              join brand in context.Brands
                              on car.BrandId equals brand.Id
                              join col in context.Colors
                              on car.ColorId equals col.Id
                              join carImage in context.CarImages
                              on car.Id equals carImage.CarId
                              select new CarDetailDto
                              {
                                  Id = car.Id,
                                  CarName = car.CarName,
                                  BrandName = brand.Name,
                                  BrandId = brand.Id,
                                  ColorName = col.Name,
                                  ColorId = col.Id,
                                  DailyPrice = car.DailyPrice,
                                  ModelYear = car.ModelYear,
                                  Description = car.Description,
                                  ImagePath = carImage.ImagePath

                              }).Where(filter).ToList();

                return result;
            }
        }
        public CarDetailDto GetCarDetail(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                // CarName, BrandName, ColorName, DailyPrice
                var result = (from car in context.Cars.Cast<Car>()
                              join brand in context.Brands
                              on car.BrandId equals brand.Id
                              join col in context.Colors
                              on car.ColorId equals col.Id
                              join carImage in context.CarImages
                              on car.Id equals carImage.CarId
                              select new CarDetailDto
                              {
                                  Id = car.Id,
                                  CarName = car.CarName,
                                  BrandName = brand.Name,
                                  BrandId = brand.Id,
                                  ColorName = col.Name,
                                  ColorId = col.Id,
                                  DailyPrice = car.DailyPrice,
                                  ModelYear = car.ModelYear,
                                  Description = car.Description,
                                  ImagePath = carImage.ImagePath

                              }).FirstOrDefault(filter);

                return result;
            }
        }
    }
}
