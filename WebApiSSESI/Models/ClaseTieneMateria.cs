using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSSESI.Models
{
    public class ClaseTieneMateria
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Clase")]
        public int ClaseId { get; set; }
        public Clase Clase { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Materia")]
        public int MateriaId { get; set; }       
        public Materia Materia { get; set; }
    }
}
