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
    public class AlumnosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AlumnosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/Alumnos
        [HttpGet]
        public IEnumerable<Alumno> Get()
        {
            return context.Alumnos.Where(x => x.EstaBorrado == false).ToList();
        }

        // GET: api/Alumnos/5
        [HttpGet("{cedula}", Name = "HijoCreado")]
        public IActionResult Get(long cedula)
        {
            var alumno = context.Alumnos.Where(x => x.Cedula == cedula)
                .Include(x => x.PadreTieneHijos).ThenInclude(y => y.Padre).ToList();
            if (alumno == null)
            {
                return NotFound();
            }
            return Ok(alumno);
        }

        // POST: api/Alumnos
        [HttpPost]
        public IActionResult Post([FromBody] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                context.Alumnos.Add(alumno);
                context.SaveChanges();

                return new CreatedAtRouteResult("HijoCreado", new { cedula = alumno.Cedula}, alumno);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/Alumnos/5
        [HttpPut("{cedula}")]
        public IActionResult Put([FromBody] Alumno alumno, long cedula)
        {
            if (alumno.Cedula != cedula)
            {
                return BadRequest();
            }
            context.Entry(alumno).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{cedula}")]
        public IActionResult Delete(long cedula)
        {
            var alumno = context.Alumnos.FirstOrDefault(x => x.Cedula == cedula);

            if (alumno == null)
            {
                return NotFound();
            }

            context.Alumnos.Remove(alumno);
            context.SaveChanges();
            return Ok(alumno);
        }
    }
}
