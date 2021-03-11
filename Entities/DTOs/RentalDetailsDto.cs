using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto
    {
        //CarId yerine BrandName, CustomerId yerine FirstName + LastName şeklinde gösteriniz
        public string BrandName { get; set; }
        public string CompanyName { get; set; }
        public string CustomerName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
