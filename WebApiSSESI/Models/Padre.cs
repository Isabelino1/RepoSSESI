using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSSESI.Models
{
    public class Padre
    {
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

        [Required(ErrorMessage = "Debe ingresar el {0}")]
        [StringLength(50, ErrorMessage = "Largo maximo 50")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Debe ingresar el {0}")]
        [StringLength(100, ErrorMessage = "Largo maximo 100")]
        public string Password { get; set; }
                
        [Range(1, 99, ErrorMessage = "El valor {0} debe ser numérico.")]
        [DefaultValue(0)]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Debe ingresar el {0}")]
        [StringLength(100, ErrorMessage = "Largo maximo 100")]
        public string Direccion { get; set; }
                
        [StringLength(20, MinimumLength =0, ErrorMessage = "Largo maximo 20")]
        [DefaultValue("Sin Datos")]
        public string Telefono { get; set; }

        [StringLength(100, MinimumLength = 0, ErrorMessage = "Largo maximo 100")]
        [DefaultValue("Sin Datos")]
        public string Trabajo { get; set; }

        [DefaultValue("false")]
        public bool Monitoreo { get; set; }

        [DefaultValue("false")]
        public bool EstaBorrado { get; set; }

        public List<PadreTieneHijo> PadreTieneHijos { get; set; }

        public List<PadreObservaMonitoreo> PadreObservaMonitoreos { get; set; }
    }
}
