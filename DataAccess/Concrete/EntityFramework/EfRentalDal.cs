using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {
        public List<RentalDetailDto> RentalDetail()
        {
            using (CarContext context = new CarContext())
            {
                var result = from re in context.Rentals
                             join ca in context.Cars
                             on re.CarId equals ca.Id
                             join b in context.Brands
                             on ca.BrandId equals b.Id
                             join cu in context.Customers
                             on re.CustomerId equals cu.Id
                             join us in context.Users
                             on cu.UserId equals us.Id
                             select new RentalDetailDto
                             {
                                 CustomerName = us.FirstName + " " + us.LastName,
                                 BrandName = b.Name,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate,
                                 CompanyName = cu.CompanyName
                             };

                return result.ToList();

            }
        }
    }
}
