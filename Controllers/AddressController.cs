//using System.Web.Http.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using BLL;
using Microsoft.AspNetCore.Cors;

namespace WebAPIHealthServices.Controllers
{
    //[EnableCors(methods: "*", origins: "*", headers: "*")]
    public class AddressController : ApiController
    {
        AddressService AddressService = new AddressService();

        // GET: api/Address
        
        public List<AddressDTO> Get()
        {
            return AddressService.Get();
        }

        // GET: api/Address/5
        public AddressDTO Get(int id)
        {
            return AddressService.Get(id);
        }

        // POST: api/Address
       
        [HttpPost]
        public IHttpActionResult Post(AddressDTO a)
        {
            if (a == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            return Ok(AddressService.Post(a));
        }

        // PUT: api/Address/5

        [HttpPut]
        public IHttpActionResult Put(int id, AddressDTO a)
        {
            return Ok(AddressService.Put(id, a));
        }

        // DELETE: api/Address/5
        public void Delete(int id)
        {
            AddressService.Delete(id);
        }
    }
}

