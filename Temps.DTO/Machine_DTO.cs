namespace Temps.DTO
{
    public class Machine_DTO
    {
        public int MachineNumber { get; set; }
        public string? MachineName { get; set; }
        public string? MachineDescription { get; set; }
        public DateTime? ServiceDate { get; set; }
        public DateTime? SignalTime { get; set; }
        public DateTime? LocalTime { get; set; }
    }
}