using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSSESI.Models
{
    public class PadreTieneHijo
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Padre")]
        public long PadreCedula { get; set; }
        public Padre Padre { get; set; }

        [Key, Column(Order =1)]
        [ForeignKey("Alumno")]
        public long AlumnoCedula { get; set; }        
        public Alumno Alumno { get; set; }
    }
}
