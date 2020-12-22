namespace PCP.Web.ViewModels.CPUs
{
    using System;

    public class CPUViewModel : BasicInfoViewModel
    {
        //public virtual ICollection<CPUUserRating> UserRatings { get; set; }

        public string SocketName { get; set; }

        public string CoreNameName { get; set; }

        public byte? Cores { get; set; }

        public short? Threads { get; set; }

        public short? Frequency { get; set; }

        public short? TurboFrequency { get; set; }

        public int? L1Cache { get; set; }

        public int? L2Cache { get; set; }

        public int? L3Cache { get; set; }

        public string LithographyName { get; set; }

        public bool? SixtyFourBitSupport { get; set; }

        public byte? MemoryChannel { get; set; }

        public string MemoryTypeType { get; set; }

        public short? MemorySpeedSpeed { get; set; }

        public bool? VirtualizationSupport { get; set; }

        public string IntegratedGraphicName { get; set; }

        public short? IntegratedGraphicBaseFrequency { get; set; }

        public short? IntegratedGraphicMaxFrequency { get; set; }

        public float? PCIERevision { get; set; }

        public byte? PCIELanes { get; set; }

        public short? ThermalDesignPower { get; set; }

        public bool? HasCoolingDevice { get; set; }

        public DateTime FirstAvailable { get; set; }
    }
}
