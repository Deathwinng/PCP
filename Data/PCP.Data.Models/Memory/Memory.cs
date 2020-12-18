namespace PCP.Data.Models.Memory
{
    using System;

    using PCP.Data.Common.Models;
    using PCP.Data.Models.Enums;

    public class Memory : BaseDeletableModel<int>
    {
        public string Model { get; set; }

        public float? Price { get; set; }

        public string ImageUrl { get; set; }

        public int? BrandId { get; set; }

        public Brand Brand { get; set; }

        public int? SeriesId { get; set; }

        public Series Series { get; set; }

        public Category Category { get; set; }

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

        public DateTime FirstAvailable { get; set; }
    }
}
