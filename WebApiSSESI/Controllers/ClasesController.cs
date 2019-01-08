using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSSESI.Models;

namespace WebApiSSESI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasesController : ControllerBase
    {
        private readonly ApplicationDbContext contexto;

        public ClasesController(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }

        // GET: api/Clases
        [HttpGet]
        public IEnumerable<Clase> Get()
        {
            return contexto.Clases.Where(x => x.EstaBorrado == false).ToList();
        }

        // GET: api/Clases/5
        [HttpGet("{id}", Name = "ClaseCreada")]
        public IActionResult Get(int id)
        {
            var clase = contexto.Clases.Where(x => x.Id == id)
                .Include(x => x.ClaseTieneMaterias).ThenInclude(y => y.Materia).ToList();
            if (clase == null)
                return NotFound();
            return Ok(clase);
        }

        // POST: api/Clases
        [HttpPost]
        public IActionResult Post([FromBody] Clase clase)
        {
            if (ModelState.IsValid)
            {
                contexto.Clases.Add(clase);
                contexto.SaveChanges();

                return new CreatedAtRouteResult("ClaseCreada", new { id = clase.Id }, clase);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Clases/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Clase clase, int id)
        {
            if (clase.Id != id)
            {
                return BadRequest();
            }

            contexto.Entry(clase).State = EntityState.Modified;
            contexto.SaveChanges();
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var clase = contexto.Clases.FirstOrDefault(x => x.Id == id);
            if (clase == null)
            {
                return BadRequest();
            }
            contexto.Clases.Remove(clase);
            contexto.SaveChanges();
            return Ok(clase);
        }
    }
}
