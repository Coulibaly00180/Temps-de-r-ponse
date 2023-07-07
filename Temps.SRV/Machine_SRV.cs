using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temps.DAL;
using Temps.DTO;

namespace Temps.SRV
{
    public class Machine_SRV : IMachine_SRV<Machine_DTO>
    {
        protected IDepot_DAL<Machine_DAL> depot_machine;

        public Machine_SRV(IDepot_DAL<Machine_DAL> depot_machine)
        {
            this.depot_machine = depot_machine;
        }

        public Machine_SRV() 
            :this(new Machine_Depot_DAL())
        { }

        public Machine_DTO Ajouter(Machine_DTO machine)
        {
            var mach = new Machine_DAL(machine.MachineNumber, machine.MachineName, machine.MachineDescription, machine.ServiceDate, machine.SignalTime, machine.LocalTime);
            depot_machine.Insert(mach);
            machine.MachineNumber = mach.MachineNumber;

            return machine;
        }

        public IEnumerable<Machine_DTO> GetAll()
        {
            // IEnumerable<Machine_DTO> machines = (IEnumerable<Machine_DTO>)depot_machine.GetAll();

            // IEnumerable<Machine_DTO> machinesDTO = new List<Machine_DTO>();

            var machines = depot_machine.GetAll();

            foreach (var machine in machines)
            {
                // Machine_DTO dto = new Machine_DTO()
                yield return new Machine_DTO()
                {
                    MachineNumber = machine.MachineNumber,
                    MachineName = machine.MachineName,
                    MachineDescription = machine.MachineDescription,
                    ServiceDate = machine.ServiceDate,
                    SignalTime = machine.SignalTime,
                    LocalTime = machine.LocalTime,
                };
                // machinesDTO.Append(dto);
            }
            // return machinesDTO;
        }

        public Machine_DTO GetById(int id)
        {
            var machine = depot_machine.GetById(id);

            return new Machine_DTO()
            {
                MachineNumber = machine.MachineNumber,
                MachineName = machine.MachineName,
                MachineDescription = machine.MachineDescription,
                ServiceDate = machine.ServiceDate,
                SignalTime = machine.SignalTime,
                LocalTime = machine.LocalTime,
            };
        }

        public Machine_DTO Modifier(Machine_DTO machineDTO)
        {
            var machine = depot_machine.GetById(machineDTO.MachineNumber);

            if(machineDTO != null)
            {
                // machine.MachineNumber = machineDTO.MachineNumber;
                machine.MachineName = machineDTO.MachineName;
                machine.MachineDescription = machineDTO.MachineDescription;
                machine.ServiceDate = machineDTO.ServiceDate;
                machine.SignalTime = machineDTO.SignalTime;
                machine.LocalTime = machineDTO.LocalTime;

                depot_machine.Update(machine);
            }

            return machineDTO;
        }

        public Machine_DTO ModifierSignal(Machine_DTO machineDTO)
        {
            var machine = depot_machine.GetById(machineDTO.MachineNumber);

            if (machineDTO != null)
            {
                // machine.MachineNumber = machineDTO.MachineNumber;
                machine.SignalTime = machineDTO.SignalTime;
                machine.LocalTime = machineDTO.LocalTime;

                depot_machine.Update(machine);
            }

            return machineDTO;
        }

        public void Supprimer(int id)
        {
            depot_machine.Delete(id);
        }
    }
}
