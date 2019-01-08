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
    public class PadresController : ControllerBase
    {
        private readonly ApplicationDbContext contexto;

        public PadresController(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }

        // GET: api/Padres
        [HttpGet]
        public IEnumerable<Padre> Get()
        {
            return contexto.Padres.Where(x => x.EstaBorrado == false).ToList();
        }

        // GET: api/Padres/5
        [HttpGet("{cedula}", Name = "PadreCreado")]
        public IActionResult Get(long cedula)
        {
            var padre = contexto.Padres.Where(x => x.Cedula == cedula)
                .Include(x => x.PadreTieneHijos).ThenInclude(y => y.Alumno).ToList();
            if (padre == null)
                return NotFound();
            return Ok(padre);
        }

        // POST: api/Padres
        [HttpPost]
        public IActionResult Post([FromBody] Padre padre, long cedulaHijo)
        {
            if (ModelState.IsValid)
            {
                //PadreTieneHijo padreTieneHijo = new PadreTieneHijo();
                //padreTieneHijo.AlumnoCedula = cedulaHijo;
                //padreTieneHijo.PadreCedula = padre.Cedula;
                //contexto.PadreTieneHijos.Add(padreTieneHijo);
                contexto.Padres.Add(padre);                
                contexto.SaveChanges();

                return new CreatedAtRouteResult("PadreCreado", new {cedula = padre.Cedula }, padre);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Padres/5
        [HttpPut("{cedula}")]
        public IActionResult Put([FromBody] Padre padre, long cedula)
        {
            if (padre.Cedula != cedula)
            {
                return BadRequest();
            }

            contexto.Entry(padre).State = EntityState.Modified;
            contexto.SaveChanges();
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{cedula}")]
        public IActionResult Delete(long cedula)
        {
            var padre = contexto.Padres.FirstOrDefault(x => x.Cedula == cedula);

            if (padre == null)
                return BadRequest();

            contexto.Padres.Remove(padre);
            contexto.SaveChanges();
            return Ok(padre);
        }
    }
}
