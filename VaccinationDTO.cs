using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class VaccinationDTO
    {
        public int NumVaccination { get; set; }
        public Nullable<DateTime> ReceivingTheVaccine { get; set; }
        public string Manufacturer { get; set; }
        public int NumCustomer { get; set; }
    }
}