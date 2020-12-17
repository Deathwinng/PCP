﻿namespace PCP.Data.Models.CPU
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using PCP.Data.Common.Models;
    using PCP.Data.Models;
    using PCP.Data.Models.Enums;

    public class CPU : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public float? Price { get; set; }

        public string ImageUrl { get; set; }

        public int? BrandId { get; set; }

        public Brand Brand { get; set; }

        public string Model { get; set; }

        public CPUType Type { get; set; }

        public int? SeriesId { get; set; }

        public Series Series { get; set; }

        public int? SocketId { get; set; }

        public Socket Socket { get; set; }

        public int? CoreNameId { get; set; }

        public CoreName CoreName { get; set; }

        public byte? Cores { get; set; }

        public short? Threads { get; set; }

        public short? Frequency { get; set; }

        public short? TurboFrequency { get; set; }

        public int? L1Cache { get; set; }

        public int? L2Cache { get; set; }

        public int? L3Cache { get; set; }

        public int? LithographyId { get; set; }

        public Lithography Lithography { get; set; }

        public bool? SixtyFourBitSupport { get; set; }

        public byte? MemoryChannel { get; set; }

        public int? MemoryTypeId { get; set; }

        public MemoryType MemoryType { get; set; }

        public int? MemorySpeedId { get; set; }

        public MemorySpeed MemorySpeed { get; set; }

        public bool? VirtualizationSupport { get; set; }

        public int? IntegratedGraphicId { get; set; }

        public IntegratedGraphic IntegratedGraphic { get; set; }

        public float? PCIERevision { get; set; }

        public byte? PCIELanes { get; set; }

        public short? ThermalDesignPower { get; set; }

        public bool? HasCoolingDevice { get; set; }

        public DateTime? FirstAvailable { get; set; }
    }
}