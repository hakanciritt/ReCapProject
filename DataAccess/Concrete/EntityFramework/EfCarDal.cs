using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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
                              select new CarDetailDto
                              {
                                  CarName = brand.Name,
                                  BrandName = brand.Name,
                                  ColorName = col.Name,
                                  DailyPrice = car.DailyPrice

                              }).ToList();

                return result;
            }

        }
    }
}
