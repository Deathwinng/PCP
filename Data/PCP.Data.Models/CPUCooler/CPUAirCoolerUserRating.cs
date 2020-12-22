namespace PCP.Data.Models.CPUCooler
{
    using PCP.Data.Models.Rating;

    public class CPUAirCoolerUserRating : UserRating
    {
        public string CPUCoolerId { get; set; }

        public virtual CPUAirCooler CPUAirCooler { get; set; }
    }
}
