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
    [Produces("application/json")]
    [Route("api/Centros/{CentroId}/TelefonoCentro")]
    [ApiController]
    public class TelefonoCentroController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public TelefonoCentroController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<TelefonoCEducativo> GetAll(int CentroId)
        {
            return context.TelefonoCEducativo.Where(x =>x.CentroId == CentroId).ToList();
        }

        [HttpGet("{id}", Name = "telefonoById")]
        public ActionResult GetById(int id)
        {
            var tel = context.TelefonoCEducativo.Where(x => x.Id == id);

            if (tel == null)
                return NotFound();
            return new ObjectResult(tel);
        }

        [HttpPost]
        public ActionResult Create([FromBody]TelefonoCEducativo telefonoCEducativo, int CentroId)
        {
            telefonoCEducativo.CentroId = CentroId;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            context.TelefonoCEducativo.Add(telefonoCEducativo);
            context.SaveChanges();

            return new CreatedAtRouteResult("telefonoById", new { id = telefonoCEducativo.Id});
        }

        [HttpPut("{id}")]
        public ActionResult UpDate([FromBody]TelefonoCEducativo telefonoCEducativo, int id)
        {
            if (telefonoCEducativo.Id != id)
                return BadRequest();

            context.Entry(telefonoCEducativo).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var tel = context.TelefonoCEducativo.FirstOrDefault(x => x.Id == id);

            if (tel == null)
                return NotFound();

            context.TelefonoCEducativo.Remove(tel);
            context.SaveChanges();
            return Ok(tel);
        }
    }
}