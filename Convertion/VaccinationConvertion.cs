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
    public class VaccinationConvertion
    {

        public static Vaccination Convert(VaccinationDTO vaccination)
        {
            if (vaccination == null)
                return null;
            return new Vaccination()
            {
                NumVaccination = vaccination.NumVaccination,
                NumCustomer = vaccination.NumCustomer,
                Manufacturer = vaccination.Manufacturer,
                ReceivingTheVaccine = vaccination.ReceivingTheVaccine,
            };
        }
        public static VaccinationDTO Convert(Vaccination vaccination)
        {
            if (vaccination == null)
                return null;
            return new VaccinationDTO()
            {
                NumVaccination = vaccination.NumVaccination,
                NumCustomer = vaccination.NumCustomer,
                Manufacturer = vaccination.Manufacturer,
                ReceivingTheVaccine = vaccination.ReceivingTheVaccine,
            };
        }
        public static List<Vaccination> Convert(List<VaccinationDTO> vaccination)
        {
            return vaccination.Select(x => Convert(x)).ToList();
        }
        public static List<VaccinationDTO> Convert(List<Vaccination> vaccination)
        {
            return vaccination.Select(x => Convert(x)).ToList();
        }
    }
}
