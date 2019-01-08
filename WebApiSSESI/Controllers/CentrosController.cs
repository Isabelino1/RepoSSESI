using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSSESI.Models;

namespace WebApiSSESI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CentrosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CentrosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<CentroEducativo> Get()
        {
            return context.CentrosEducativos.ToList();
        }

        [HttpGet("{id}", Name = "centroCreado")]
        public IActionResult GetById(int id)
        {
            var centro = context.CentrosEducativos.Include(x => x.Telefonos).FirstOrDefault(x => x.Id == id);

            if (centro == null)
            {
                return NotFound();
            }
            return Ok(centro);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CentroEducativo centro)
        {
            if (ModelState.IsValid)
            {
                context.CentrosEducativos.Add(centro);
                context.SaveChanges();

                return new CreatedAtRouteResult("centroCreado", new { id = centro.Id}, centro);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] CentroEducativo centro, int id)
        {
            if (centro.Id != id)
                return BadRequest();

            context.Entry(centro).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var centro = context.CentrosEducativos.FirstOrDefault(x => x.Id == id);

            if (centro == null)
                return NotFound();

            context.CentrosEducativos.Remove(centro);
            context.SaveChanges();
            return Ok(centro);
        }
    }
}