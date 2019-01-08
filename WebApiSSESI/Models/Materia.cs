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
    public class Materia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar el {0}")]
        [StringLength(50, ErrorMessage = "Largo maximo 50")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar el {0}")]
        [StringLength(20, ErrorMessage = "Largo maximo 20")]
        public string CargaHoraria { get; set; }

        [DefaultValue("false")]
        public bool EstaBorrado { get; set; }

        [ForeignKey("CentroEducativo")]
        public int CentroId { get; set; }
        [JsonIgnore]
        public CentroEducativo CentroEducativo { get; set; }

        public List<ClaseTieneMateria> ClaseTieneMaterias { get; set; }

    }
}
