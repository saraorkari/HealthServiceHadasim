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
    public class CustomerService
    {
        // GET: api/Customer
        public List<CustomerDTO> Get()
        {
            using (dbHealthServicesEntities db = new dbHealthServicesEntities())
            {
                //db.Customer.ToList().ForEach(x => x = Convertion.CustomerConvertion.Convert(Get(x.NumCustomer)));
                return Convertion.CustomerConvertion.Convert(db.Customer.ToList());
            }
        }
        public int Get(bool flag)
        {
            using (dbHealthServicesEntities db = new dbHealthServicesEntities())
            {
                return db.Customer.Count(x => x.Vaccination.Count == 0);
            }
        }

        // GET: api/Customer/5
        public CustomerDTO Get(int num)
        {
            using (dbHealthServicesEntities db = new dbHealthServicesEntities())
            {
                //להחזיר עם הלקוח גם את החיסון במקום לקרוא פעמיים לשרת
                CustomerDTO customer = Convertion.CustomerConvertion.Convert(db.Customer.FirstOrDefault(x => x.NumCustomer == num));
                customer.Count = db.Vaccination.Count(x => x.NumCustomer == customer.NumCustomer);
                customer.Address = Convertion.AddressConvertion.Convert(db.Address.FirstOrDefault(x => x.AddressId == customer.AddressId));
                customer.Vaccination = Convertion.VaccinationConvertion.Convert(db.Vaccination.Where(x => x.NumCustomer == customer.NumCustomer).ToList());
                return customer;
            }
        }

        // POST: api/Customer
        public CustomerDTO Post(CustomerDTO a)
        {
            using (dbHealthServicesEntities db = new dbHealthServicesEntities())
            {
                Customer Customer = null;
                if (db.Customer.FirstOrDefault(x => x.Id == a.Id) != null)
                {
                    a = Convertion.CustomerConvertion.Convert(db.Customer.FirstOrDefault(x => x.Id == a.Id));
                    Customer = Convertion.CustomerConvertion.Convert(Put(a.Id, a));
                }
                else
                {
                    db.Customer.FirstOrDefault(x => x.NumCustomer == a.NumCustomer).img = a.Img;
                    Address address = db.Address.Add(Convertion.AddressConvertion.Convert(a.Address));
                    db.SaveChanges();
                    a.AddressId = address.AddressId;
                    if (a.Vaccination != null)
                    {
                        a.Vaccination.ForEach(x => x.NumCustomer = a.NumCustomer);
                        List<Vaccination> vaccination = db.Vaccination.AddRange(Convertion.VaccinationConvertion.Convert(a.Vaccination)).ToList();
                    }
                    Customer = db.Customer.Add(Convertion.CustomerConvertion.Convert(a));
                    db.SaveChanges();
                }
                return Convertion.CustomerConvertion.Convert(Customer);
            }
        }
        //public string Post(Customer customer)
        //{
        //    using (dbHealthServicesEntities db = new dbHealthServicesEntities())
        //    {
        //        db.Customer.FirstOrDefault(x => x.NumCustomer == customer.NumCustomer).img = customer.img;
        //        db.SaveChanges();
        //    }
        //    return customer.img;
        //}

        // PUT: api/Customer/5
        public CustomerDTO Put(string id, CustomerDTO a)
        {
            using (dbHealthServicesEntities db = new dbHealthServicesEntities())
            {
                db.Customer.FirstOrDefault(x => x.NumCustomer == a.NumCustomer).img = a.Img;
                Address address = db.Address.Add(Convertion.AddressConvertion.Convert(a.Address));
                db.SaveChanges();
                a.AddressId = address.AddressId;
                if (a.Vaccination != null && a.Vaccination.Count() < 4)
                {
                    a.Vaccination.ForEach(x => x.NumCustomer = a.NumCustomer);
                    List<Vaccination> vaccination = db.Vaccination.AddRange(Convertion.VaccinationConvertion.Convert(a.Vaccination)).ToList();
                }
                Customer aa = db.Customer.FirstOrDefault(x => x.Id == id);
                if (aa != null)
                {
                    aa.Id = a.Id;
                    aa.FirstName = a.FirstName;
                    aa.LastName = a.LastName;
                    aa.Mobile = a.Mobile;
                    aa.Telephone = a.Telephone;
                    aa.AddressId = a.AddressId;
                    aa.Cuvid19Positive = a.Cuvid19Positive;
                    aa.DateOfBirth = a.DateOfBirth;
                    aa.Recovery = a.Recovery;
                    aa.VaccinationId = a.VaccinationId;
                    db.SaveChanges();
                    return Convertion.CustomerConvertion.Convert(aa);
                }
                return null;
            }
        }

        // DELETE: api/Customer/5
        public void Delete(int num)
        {
            using (dbHealthServicesEntities db = new dbHealthServicesEntities())
            {
                Customer aa = db.Customer.FirstOrDefault(x => x.NumCustomer == num);
                List<Vaccination> vaccination = db.Vaccination.Where(x => x.NumCustomer == aa.NumCustomer).ToList();
                db.Vaccination.RemoveRange(vaccination);
                db.Customer.Remove(aa);
                db.SaveChanges();
            }
        }
    }
}
