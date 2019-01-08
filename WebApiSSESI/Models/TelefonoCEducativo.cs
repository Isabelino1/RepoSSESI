using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSSESI.Models
{
    public class TelefonoCEducativo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar un telefono")]
        [StringLength(50, ErrorMessage = "Largo maximo 50")]
        public string Telefono { get; set; }

        [ForeignKey("CentroEducativo")]
        public int CentroId { get; set; }
        
        public CentroEducativo CentroEducativo { get; set; }


    }
}
