using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiSSESI.Models
{
    public class Alumno
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Debe ingresar el {0}")]
        [StringLength(9, ErrorMessage = "Largo maximo 9 digitos")]
        [Range(111111111, 799999999, ErrorMessage = "El valor {0} debe ser numérico.")]
        public long Cedula { get; set; }

        [Required(ErrorMessage = "Debe ingresar el {0}")]
        [StringLength(100, ErrorMessage = "Largo maximo 100")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Números y caracteres especiales no son permitidos en el nombre.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar el {0}")]
        [StringLength(100, ErrorMessage = "Largo maximo 100")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Números y caracteres especiales no son permitidos en el apellido.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Debe ingresar Fecha de Nacimiento")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Debe de ingresar la {0}.")]
        [Range(1, 99, ErrorMessage = "El valor {0} debe ser numérico.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Debe ingresar el {0}")]
        [StringLength(100, ErrorMessage = "Largo maximo 100")]
        public string Domicilio { get; set; }

        [Required(ErrorMessage = "Debe ingresar el {0}")]
        [StringLength(100, ErrorMessage = "Largo maximo 100")]
        public string Barrio { get; set; }

        [StringLength(20, MinimumLength =0, ErrorMessage = "Largo maximo 20")]
        [DefaultValue("Sin Datos")]
        public string Telefono { get; set; }

        [StringLength(100, MinimumLength =0, ErrorMessage = "Largo maximo 100")]
        [DefaultValue("Sin Datos")]
        public string Emergencia { get; set; }

        [StringLength(20, MinimumLength =0, ErrorMessage = "Largo maximo 20")]
        [DefaultValue("Sin Datos")]
        public string TelEmergencia { get; set; }

        [DefaultValue("false")]
        public bool EstaBorrado { get; set; }

        [ForeignKey("Clase")]
        public int ClaseId { get; set; }        
        public Clase Clase { get; set; }

        public List<PadreTieneHijo> PadreTieneHijos { get; set; }
    }
}
