using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temps.DTO
{
    public class MachineSignal_DTO
    {
        public DateTime? ServiceDate { get; set; }
        public DateTime? SignalTime { get; set; }
        public DateTime? LocalTime { get; set; }
    }
}
