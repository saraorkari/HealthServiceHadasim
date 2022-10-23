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
    public class AddressConvertion
    {

        public static Address Convert(AddressDTO address)
        {
            if (address == null)
                return null;
            return new Address()
            {
                AddressId = address.AddressId,
                City = address.City,
                Street = address.Street,
                Number = address.Number,
            };
        }
        public static AddressDTO Convert(Address address)
        {
            if (address == null)
                return null;
            return new AddressDTO()
            {
                AddressId = address.AddressId,
                City = address.City,
                Street = address.Street,
                Number = address.Number,
            };
        }
        public static List<Address> Convert(List<AddressDTO> address)
        {
            return address.Select(x => Convert(x)).ToList();
        }
        public static List<AddressDTO> Convert(List<Address> address)
        {
            return address.Select(x => Convert(x)).ToList();
        }
    }
}
