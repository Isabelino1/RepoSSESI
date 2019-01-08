using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSSESI.Models
{
    public class ApplicationDbContext : DbContext//IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ClaseTieneMateria>().HasKey(x => new { x.ClaseId, x.MateriaId });
            //Usando el Api fluente para indicar una clave compuesta para la tabla ClaseTieneMateria

            builder.Entity<PadreTieneHijo>().HasKey(x => new { x.AlumnoCedula, x.PadreCedula});
            builder.Entity<Padre>().HasIndex(b => b.Username).IsUnique();
            builder.Entity<ClaseDelAlumno>().HasKey(x => new { x.ClaseId, x.AlumnoCedula });
            builder.Entity<PadreObservaMonitoreo>().HasKey(x => new { x.PadreCedula, x.MonitoreoNumeroContrato });
        }

        public DbSet<CentroEducativo> CentrosEducativos { get; set; }
        public DbSet<TelefonoCEducativo> TelefonoCEducativo { get; set; }
        public DbSet <Clase> Clases { get; set; }
        public DbSet <Materia> Materias { get; set; }
        public DbSet <ClaseTieneMateria> ClaseTieneMaterias { get; set; }
        public DbSet <Alumno> Alumnos { get; set; }
        public DbSet <Padre> Padres { get; set; }
        public DbSet <PadreTieneHijo> PadreTieneHijos { get; set; }
        public DbSet<Monitoreo> Monitoreos { get; set; }
        public DbSet<PadreObservaMonitoreo> PadreObservaMonitoreos { get; set; }
    }
}
