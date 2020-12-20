namespace PCP.Data.Models.CPUCooler
{
    using PCP.Data.Models.Rating;

    public class CPUAirCoolerUserRating : UserRating
    {
        public string CPUCoolerId { get; set; }

        public CPUAirCooler CPUAirCooler { get; set; }
    }
}
