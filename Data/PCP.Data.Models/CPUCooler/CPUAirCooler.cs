namespace PCP.Data.Models.CPUCooler
{
    using System.Collections.Generic;

    using PCP.Data.Models;

    public class CPUAirCooler : BaseProduct
    {
        public CPUAirCooler()
        {
            this.Sockets = new HashSet<CPUAirCoolerSocket>();
            this.UserRatings = new HashSet<CPUAirCoolerUserRating>();
        }

        public ICollection<CPUAirCoolerUserRating> UserRatings { get; set; }

        public int? CoolerTypeId { get; set; }

        public CoolerType CoolerType { get; set; }

        public short? FanSize { get; set; }

        public ICollection<CPUAirCoolerSocket> Sockets { get; set; }

        public int? CoolerBearingTypeId { get; set; }

        public CoolerBearingType CoolerBearingType { get; set; }

        public short? RPM { get; set; }

        public float? MaxAirFlow { get; set; }

        public float? MaxNoiseLevel { get; set; }

        public byte? PowerConnectorPins { get; set; }

        public int? ColorId { get; set; }

        public Color Color { get; set; }

        public int? CoolerLEDId { get; set; }

        public CoolerLEDType CoolerLED { get; set; }

        public string HeatsinkMaterial { get; set; }

        public byte? MaxHeight { get; set; }

        public string FanDimensions { get; set; }

        public string HeatsinkDimension { get; set; }

        public string Features { get; set; }
    }
}
