using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class AddressDTO
    {
        public int AddressId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public Nullable<int> Number { get; set; }
    }
}