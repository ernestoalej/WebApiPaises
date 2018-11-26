using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPaises.Models;

namespace WebApiPaises.Controllers
{
    [Produces("application/json")]
    //[Route("api/Pais/{PaisId}/Provincia")]
    [Route("api")]

    public class ProvinciaController : Controller
    {
        private readonly AppDbContext context;

        public ProvinciaController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet("Provincia")]
        public IEnumerable<Provincia> Get()
        {
            var pais = context.Provincias.ToList();


            return pais;
        }


        [HttpGet("Pais/{PaisId}/Provincia/{ProvId}")]
        public IEnumerable<Provincia> GetByID(int PaisId, int ProvId)
        {                    
            var pais= context.Provincias.Where(p => p.PaisId == PaisId).Where(p => p.Id == ProvId); 
           
            return pais;
        }

        [HttpGet("Provincia/{ProvId}", Name= "GetProvincia")]
        public IActionResult GetProvincia(int ProvID)
        {
            var prov = context.Provincias.FirstOrDefault( p=> p.Id == ProvID);

            if (prov == null)
            {
                return NotFound();
            }
               
            return Ok(prov);
          
        }

        [HttpPost("Provincia")]
        public IActionResult Post([FromBody] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                context.Provincias.Add(provincia);
                context.SaveChanges();

                return new CreatedAtRouteResult("GetProvincia", new { ProvID = provincia.Id }, provincia);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("Provincia/{ProvId}")]
        public IActionResult Put([FromBody] Provincia provincia, int ProvId)
        {
            if (ProvId!= provincia.Id)
            {
                return BadRequest();
            }

            context.Entry(provincia).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();            
        }

        [HttpDelete("Provincia/{ProvId}")]
        public IActionResult Delete(int ProvId)
        {
            var prov = context.Provincias.FirstOrDefault(p=> p.Id== ProvId);

            if (prov== null)
            {
                return NotFound();
            }

            context.Provincias.Remove(prov);
            context.SaveChanges();

            return Ok();
            
        }


        




    }
}