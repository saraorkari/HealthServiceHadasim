using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using BLL;
//using System.Web.Http.Cors;
//using Microsoft.AspNetCore.Cors;

namespace WebAPIHealthServices.Controllers
{

    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CustomerController : ApiController
    {
        CustomerService CustomerService = new CustomerService();

        // GET: api/Customer
        public List<CustomerDTO> Get()
        {
            return CustomerService.Get();
        }
        public int Get(bool flag)
        {
            return CustomerService.Get(flag);
        }


        // GET: api/Customer/5
        public CustomerDTO Get(int num)
        {
            return CustomerService.Get(num);
        }

        // POST: api/Customer

        [HttpPost]
        public IHttpActionResult Post(CustomerDTO a)
        {
            if (a == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            return Ok(CustomerService.Post(a));
        }
        // PUT: api/Customer/5

        [HttpPut]
        public IHttpActionResult Put(string id, CustomerDTO a)
        {
            return Ok(CustomerService.Put(id, a));
        }

        // DELETE: api/Customer/5
        public void Delete(int num)
        {
            CustomerService.Delete(num);
        }
    }
}

