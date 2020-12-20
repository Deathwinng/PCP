namespace PCP.Data.Models.CPUCooler
{
    using PCP.Data.Common.Models;

    public class CPUAirCoolerSocket : BaseDeletableModel<int>
    {
        public string CPUAirCoolerId { get; set; }

        public CPUAirCooler CPUAirCooler { get; set; }

        public int SocketId { get; set; }

        public Socket Socket { get; set; }
    }
}
