namespace PCP.Services.Models
{
    using System;

    public class CPUDto
    {
        public string Name { get; set; }

        public int BrandId { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }

        public string Series { get; set; }

        public int SocketId { get; set; }

        public string Socket { get; set; }

        public string CoreName { get; set; }

        public byte Cores { get; set; }

        public short Threads { get; set; }

        public short Frequency { get; set; }

        public short TurboFrequency { get; set; }

        public int? L1Cache { get; set; }

        public int? L2Cache { get; set; }

        public int? L3Cache { get; set; }

        public int? LithographyId { get; set; }

        public string Lithography { get; set; }

        public bool? SixtyFourBitSupport { get; set; }

        public byte MemoryChannel { get; set; }

        public int MemoryTypeAndSpeedId { get; set; }

        public string MemoryType { get; set; }

        public short MemorySpeed { get; set; }

        public bool VirtualizationSupport { get; set; }

        public int? IntegratedGraphicId { get; set; }

        public string IntegratedGraphic { get; set; }

        public short? IntegratedGraphicBaseFrequency { get; set; }

        public short? IntegratedGraphicMaxFrequency { get; set; }

        public float? PCIERevision { get; set; }

        public byte? PCIELanes { get; set; }

        public short ThermalDesignPower { get; set; }

        public bool HasCoolingDevice { get; set; }

        public string CoolingDevice { get; set; }

        public DateTime FirstAvailable { get; set; }
    }
}
