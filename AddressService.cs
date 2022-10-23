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
    public class AddressService
    {
        // GET: api/Address
        public List<AddressDTO> Get()
        {
            using (dbHealthServicesEntities db = new dbHealthServicesEntities())
            {
                return Convertion.AddressConvertion.Convert(db.Address.ToList());
            }
        }

        // GET: api/Address/5
        public AddressDTO Get(int id)
        {
            using (dbHealthServicesEntities db = new dbHealthServicesEntities())
            {
                Convertion.AddressConvertion.Convert(db.Address.FirstOrDefault(x => x.AddressId == id));
            }
            return null;
        }

        // POST: api/Address
        public AddressDTO Post(AddressDTO a)
        {
            using (dbHealthServicesEntities db = new dbHealthServicesEntities())
            {
                Address address = db.Address.Add(Convertion.AddressConvertion.Convert(a));
                db.SaveChanges();
                return Convertion.AddressConvertion.Convert(address);
            }
        }

        // PUT: api/Address/5
        public AddressDTO Put(int id, AddressDTO a)
        {
            using (dbHealthServicesEntities db = new dbHealthServicesEntities())
            {
                Address aa = db.Address.FirstOrDefault(x => x.AddressId == id);
                if (aa != null)
                {
                    aa.City = a.City;
                    aa.Street = a.Street;
                    aa.Number = a.Number;
                    db.SaveChanges();
                    return Convertion.AddressConvertion.Convert(aa);
                }
                return null;
            }
        }

        // DELETE: api/Address/5
        public void Delete(int id)
        {
            using (dbHealthServicesEntities db = new dbHealthServicesEntities())
            {
                Address aa = db.Address.FirstOrDefault(x => x.AddressId == id);
                db.Address.Remove(aa);
                db.SaveChanges();
            }
        }
    }
}
