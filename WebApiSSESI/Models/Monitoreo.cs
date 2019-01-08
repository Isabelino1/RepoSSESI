using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSSESI.Models
{
    public class Monitoreo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Debe ingresar el numero de contrato")]
        public string NumeroContrato { get; set; }

        [Required(ErrorMessage = "Debe ingresar Fecha de Inicio del Contrato")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "Debe ingresar Fecha de Fin del Contrato")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaFin { get; set; }

        [Required]
        public double Longitud { get; set; }
        [Required]
        public double Latitud { get; set; }

        [Required(ErrorMessage = "Error, falta fecha de la ubicacion")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaHoraUbicacion { get; set; }

        [ForeignKey("Alumno")]
        public long AlumnoCedula { get; set; }
        public Alumno Alumno { get; set; }

        public List<PadreObservaMonitoreo> PadreObservaMonitoreos { get; set; }

    }
}
