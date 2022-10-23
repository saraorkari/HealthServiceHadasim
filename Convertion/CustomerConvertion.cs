using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL.Convertion
{
    public class CustomerConvertion
    {

        public static Customer Convert(CustomerDTO customer)
        {
            if (customer == null)
                return null;
            return new Customer()
            {
                Id = customer.Id,
                NumCustomer = customer.NumCustomer,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Mobile = customer.Mobile,
                Telephone = customer.Telephone,
                AddressId = customer.AddressId,
                Cuvid19Positive = customer.Cuvid19Positive,
                DateOfBirth = customer.DateOfBirth,
                Recovery = customer.Recovery,
                VaccinationId = customer.VaccinationId,
                Address = Convertion.AddressConvertion.Convert(customer.Address),
                //Vaccination = Convertion.VaccinationConvertion.Convert(customer.Vaccination),
                img = customer.Img
            };
        }
        public static CustomerDTO Convert(Customer customer)
        {
            if (customer == null)
                return null;
            return new CustomerDTO()
            {
                Id = customer.Id,
                NumCustomer = customer.NumCustomer,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Mobile = customer.Mobile,
                Telephone = customer.Telephone,
                AddressId = customer.AddressId,
                Cuvid19Positive = customer.Cuvid19Positive,
                DateOfBirth = customer.DateOfBirth,
                Recovery = customer.Recovery,
                VaccinationId = customer.VaccinationId,
                Address = Convertion.AddressConvertion.Convert(customer.Address),
                Img = customer.img
            };
        }
        public static List<Customer> Convert(List<CustomerDTO> customer)
        {
            return customer.Select(x => Convert(x)).ToList();
        }
        public static List<CustomerDTO> Convert(List<Customer> customer)
        {
            return customer.Select(x => Convert(x)).ToList();
        }
    }
}
