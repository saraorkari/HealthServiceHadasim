using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using DTO;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class VaccinationService
    {
        // GET: api/Vaccination
        public List<VaccinationDTO> Get()
        {
            using (dbHealthServicesEntities db = new dbHealthServicesEntities())
            {
                return Convertion.VaccinationConvertion.Convert(db.Vaccination.ToList());
            }
        }

        // GET: api/Vaccination/5
        public VaccinationDTO Get(int id)
        {
            using (dbHealthServicesEntities db = new dbHealthServicesEntities())
            {
                Convertion.VaccinationConvertion.Convert(db.Vaccination.FirstOrDefault(x => x.NumVaccination == id));
            }
            return null;
        }

        // POST: api/Vaccination
        public VaccinationDTO Post(VaccinationDTO a)
        {
            using (dbHealthServicesEntities db = new dbHealthServicesEntities())
            {
                Vaccination vaccination = db.Vaccination.Add(Convertion.VaccinationConvertion.Convert(a));
                db.SaveChanges();
                return Convertion.VaccinationConvertion.Convert(vaccination);
            }
        }

        // PUT: api/Vaccination/5
        public VaccinationDTO Put(int id, VaccinationDTO a)
        {
            using (dbHealthServicesEntities db = new dbHealthServicesEntities())
            {
                Vaccination aa = db.Vaccination.FirstOrDefault(x => x.NumVaccination == id);
                if (aa != null)
                {
                    aa.ReceivingTheVaccine = a.ReceivingTheVaccine;
                    aa.Manufacturer = a.Manufacturer;
                    aa.NumCustomer = a.NumCustomer;
                    db.SaveChanges();
                    return Convertion.VaccinationConvertion.Convert(aa);
                }
                return null;
            }
        }

        // DELETE: api/Vaccination/5
        public void Delete(int id)
        {
            using (dbHealthServicesEntities db = new dbHealthServicesEntities())
            {
                Vaccination aa = db.Vaccination.FirstOrDefault(x => x.NumVaccination == id);
                db.Vaccination.Remove(aa);
                db.SaveChanges();
            }
        }
    }
}
