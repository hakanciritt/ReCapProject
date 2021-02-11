using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.CarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " " + car.ColorName + " " + car.BrandName + " " + car.DailyPrice);
                }
            }

            Console.WriteLine("------------------------------------------------------");

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var customerResult = customerManager.GetAll();
            
            if (customerResult.Success)
            {
                foreach (var customer in customerResult.Data)
                {
                    Console.WriteLine(customer.UserId + " " + customer.CompanyName);
                }
            }

            Console.ReadKey();

        }
    }
}
