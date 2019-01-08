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
    public class MonitoreoController : ControllerBase
    {
        private readonly ApplicationDbContext contexto;

        public MonitoreoController(ApplicationDbContext context)
        {
            this.contexto = context;
        }

        // GET: api/Monitoreo
        [HttpGet]
        public IEnumerable<Monitoreo> Get()
        {
            return contexto.Monitoreos.ToList();            
        }

        // GET: api/Monitoreo/5
        [HttpGet("{cedula}", Name = "UbicacionRegistrada")]
        public IActionResult Get(long cedula)
        {
            var lista = contexto.Monitoreos.Where(x => x.AlumnoCedula == cedula)
                .Include(x => x.PadreObservaMonitoreos).ThenInclude(y => y.Padre)
                .OrderByDescending(x => x.FechaHoraUbicacion).ToList();
            var monitoreo = lista.FirstOrDefault();

            if (monitoreo == null)
                return NotFound();
            return Ok(monitoreo);
        }

        // POST: api/Monitoreo
        [HttpPost]
        public IActionResult Post([FromBody] Monitoreo monitoreo)
        {
            if (ModelState.IsValid)
            {
                contexto.Monitoreos.Add(monitoreo);
                contexto.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Monitoreo/5
        [HttpPut("{numeroContrato}")]
        public IActionResult Put([FromBody] Monitoreo monitoreo, string numeroContrato)
        {
            if (monitoreo.NumeroContrato != numeroContrato)
                return BadRequest();

            contexto.Entry(monitoreo).State = EntityState.Modified;
            contexto.SaveChanges();
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{numeroContrato}")]
        public IActionResult Delete(string numeroContrato)
        {
            var monitoreo = contexto.Monitoreos.FirstOrDefault(x => x.NumeroContrato == numeroContrato);
            if (monitoreo == null)
                return NotFound();

            contexto.Monitoreos.Remove(monitoreo);
            contexto.SaveChanges();
            return Ok(monitoreo);
        }
    }
}
