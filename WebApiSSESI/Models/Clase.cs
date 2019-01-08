using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSSESI.Models
{
    public class Clase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar el {0}")]
        [StringLength(5, ErrorMessage = "Largo maximo 5")]
        public string Grado { get; set; }

        [Required(ErrorMessage = "Debe ingresar el {0}")]
        [StringLength(20, ErrorMessage = "Largo maximo 20")]
        public string Grupo { get; set; }

        [Required(ErrorMessage = "Debe ingresar el {0}")]
        [StringLength(20, ErrorMessage = "Largo maximo 20")]
        public string Horario { get; set; }

        [DefaultValue("false")]
        public bool EstaBorrado { get; set; }

        [ForeignKey("CentroEducativo")]
        public int CentroId { get; set; }
        [JsonIgnore]
        public CentroEducativo CentroEducativo { get; set; }

        public List<Alumno> Alumnos { get; set; }

        public List<ClaseTieneMateria> ClaseTieneMaterias { get; set; }
    }
}
