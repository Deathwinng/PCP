namespace PCP.Data.Models.CPU
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PCP.Data.Models;

    public class CPU : BaseProduct
    {
        public CPU()
        {
            this.UserRatings = new HashSet<CPUUserRating>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<CPUUserRating> UserRatings { get; set; }

        public int? SocketId { get; set; }

        public virtual Socket Socket { get; set; }

        public int? CoreNameId { get; set; }

        public virtual CoreName CoreName { get; set; }

        public byte? Cores { get; set; }

        public short? Threads { get; set; }

        public short? Frequency { get; set; }

        public short? TurboFrequency { get; set; }

        public int? L1Cache { get; set; }

        public int? L2Cache { get; set; }

        public int? L3Cache { get; set; }

        public int? LithographyId { get; set; }

        public virtual Lithography Lithography { get; set; }

        public bool? SixtyFourBitSupport { get; set; }

        public byte? MemoryChannel { get; set; }

        public int? MemoryTypeId { get; set; }

        public virtual MemoryType MemoryType { get; set; }

        public int? MemorySpeedId { get; set; }

        public virtual MemorySpeed MemorySpeed { get; set; }

        public bool? VirtualizationSupport { get; set; }

        public int? IntegratedGraphicId { get; set; }

        public virtual IntegratedGraphic IntegratedGraphic { get; set; }

        public float? PCIERevision { get; set; }

        public byte? PCIELanes { get; set; }

        public short? ThermalDesignPower { get; set; }

        public bool? HasCoolingDevice { get; set; }
    }
}
