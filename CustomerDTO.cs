using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class CustomerDTO
    {
        public int NumCustomer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public int AddressId { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Img { get; set; }
        public int VaccinationId { get; set; }
        public int Count { get; set; }
        public List<VaccinationDTO> Vaccination { get; set; }
        public AddressDTO Address { get; set; }
        public Nullable<DateTime> Cuvid19Positive { get; set; }
        public Nullable<DateTime> Recovery { get; set; }


    }
}