namespace PCP.Data.Models.Memory
{
    using System.Collections.Generic;

    public class Memory : BaseProduct
    {
        public Memory()
        {
            this.UserRatings = new HashSet<MemoryUserRating>();
        }

        public ICollection<MemoryUserRating> UserRatings { get; set; }

        public byte? NumberOfModules { get; set; }

        public int? CapacityPerModule { get; set; }

        public int? MemoryTypeId { get; set; }

        public MemoryType MemoryType { get; set; }

        public int? MemorySpeedId { get; set; }

        public MemorySpeed MemorySpeed { get; set; }

        public float? ColumnAddressStrobeLatency { get; set; }

        public string Timings { get; set; }

        public float? Voltage { get; set; }

        public bool HeatSpreader { get; set; }

        public string Features { get; set; }
    }
}
