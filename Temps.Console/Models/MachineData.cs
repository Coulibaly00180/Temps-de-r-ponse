using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Temps.Console.Models
{

    public class MachineData : INotifyPropertyChanged
    {
        public int machineNumber { get; set; }
        private int MachineNumber
        {
            get { return machineNumber; }
            set
            {
                if (machineNumber != value)
                {
                    machineNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime signalTime;
        public DateTime SignalTime
        {
            get { return signalTime; }
            set
            {
                if (signalTime != value)
                {
                    signalTime = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime localTime;
        public DateTime LocalTime
        {
            get { return localTime; }
            set
            {
                if (localTime != value)
                {
                    localTime = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
