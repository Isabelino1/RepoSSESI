using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSSESI.Models
{
    public class PadreObservaMonitoreo
    {
        public long PadreCedula { get; set; }
        public Padre Padre { get; set; }

        public string MonitoreoNumeroContrato { get; set; }
        public Monitoreo Monitoreo { get; set; }
    }
}
