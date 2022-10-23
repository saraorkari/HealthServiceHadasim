using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using BLL;
//using System.Web.Http.Cors;
using Microsoft.AspNetCore.Cors;

namespace WebAPIHealthServices.Controllers
{

    //[EnableCors(methods: "*", origins: "*", headers: "*")]
    public class VaccinationController : ApiController
    {
        VaccinationService VaccinationService = new VaccinationService();

        // GET: api/Vaccination
        public List<VaccinationDTO> Get()
        {
            return VaccinationService.Get();
        }

        // GET: api/Vaccination/5
        public VaccinationDTO Get(int id)
        {
            return VaccinationService.Get(id);
        }

        // POST: api/Vaccination

        [HttpPost]
        public IHttpActionResult Post(VaccinationDTO a)
        {
            if (a == null)
            {
                return BadRequest("לא נשלח מידע");
            }
            return Ok(VaccinationService.Post(a));
        }

        // PUT: api/Vaccination/5

        [HttpPut]
        public IHttpActionResult Put(int id, VaccinationDTO a)
        {
            return Ok(VaccinationService.Put(id, a));
        }

        // DELETE: api/Vaccination/5
        public void Delete(int id)
        {
            VaccinationService.Delete(id);
        }
    }
}

