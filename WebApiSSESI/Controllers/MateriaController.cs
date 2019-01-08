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
    public class MateriaController : ControllerBase
    {
        private readonly ApplicationDbContext contexto;

        public MateriaController(ApplicationDbContext context)
        {
            this.contexto = context;
        }
        // GET: api/Materia
        [HttpGet]
        public IEnumerable<Materia> Get()
        {
            return contexto.Materias.Where(x => x.EstaBorrado == false).ToList();
        }

        // GET: api/Materia/5
        [HttpGet("{id}", Name = "MateriaCreada")]
        public IActionResult Get(int id)
        {
            var materia = contexto.Materias.Where(x => x.Id == id)
                .Include(x => x.ClaseTieneMaterias).ThenInclude(y => y.Clase);
            if (materia == null)
                return NotFound();
            return Ok(materia);
        }

        // POST: api/Materia
        [HttpPost]
        public IActionResult Post([FromBody] Materia materia)
        {
            if (ModelState.IsValid)
            {
                contexto.Materias.Add(materia);
                contexto.SaveChanges();

                return new CreatedAtRouteResult("MateriaCreada", new { id = materia.Id}, materia);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Materia/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Materia materia, int id)
        {
            if (materia.Id != id)
                return BadRequest();

            contexto.Entry(materia).State = EntityState.Modified;
            contexto.SaveChanges();
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var materia = contexto.Materias.FirstOrDefault(x => x.Id == id);
            if (materia == null)
                return BadRequest();

            contexto.Materias.Remove(materia);
            contexto.SaveChanges();
            return Ok(materia);
        }
    }
}
