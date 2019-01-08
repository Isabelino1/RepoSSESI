using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSSESI.Models
{
    public class CentroEducativo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [StringLength(100, ErrorMessage ="Largo maximo 100")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar una direccion")]
        [StringLength(100, ErrorMessage = "Largo maximo 100")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Debe ingresar el barrio")]
        [StringLength(50, ErrorMessage = "Largo maximo 50")]
        public string Barrio { get; set; }
        [DefaultValue("false")]
        public bool EstaBorrado { get; set; }

        public List<TelefonoCEducativo> Telefonos { get; set; }
        public List<Clase> Clases { get; set; }
        public List<Materia> Materias { get; set; }
               
        public CentroEducativo()
        {
            Telefonos = new List<TelefonoCEducativo>();
            Clases = new List<Clase>();
            Materias = new List<Materia>();
        }
    }
}
