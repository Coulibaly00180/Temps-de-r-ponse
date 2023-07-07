using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temps.DAL
{
    public class Machine_DAL
    {
        public int MachineNumber { get; set; }
        public string? MachineName { get; set; }
        public string? MachineDescription { get; set;}
        public DateTime? ServiceDate { get; set; }
        public DateTime? SignalTime { get; set; }
        public DateTime? LocalTime { get; set; }

        /*
        public Machine_DAL(int machineNumber, DateTime? signalTime, DateTime? localTime)
        {
            MachineNumber = machineNumber;
            SignalTime = signalTime;
            LocalTime = localTime;
        }
        */

        public Machine_DAL(int machineNumber, string? machineName, string? machineDescription, DateTime? serviceDate, DateTime? signalTime, DateTime? localTime)
        {
            MachineNumber = machineNumber;
            MachineName = machineName;
            MachineDescription = machineDescription;
            ServiceDate = serviceDate;
            SignalTime = signalTime;
            LocalTime = localTime;
        }
    }
}
