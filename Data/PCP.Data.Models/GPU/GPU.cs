namespace PCP.Data.Models.GPU
{
    using System;
    using System.Collections.Generic;

    using PCP.Data.Common.Models;
    using PCP.Data.Models.Enums;

    public class GPU : BaseDeletableModel<int>
    {
        public GPU()
        {
            this.GPUPorts = new HashSet<GPUPort>();
        }

        public float? Price { get; set; }

        public string ImageUrl { get; set; }

        public int? BrandId { get; set; }

        public Brand Brand { get; set; }

        public string Model { get; set; }

        public int? SeriesId { get; set; }

        public Series Series { get; set; }

        public Category Category { get; set; }

        public int? GPUInterfaceId { get; set; }

        public GPUInterface GPUInterface { get; set; }

        public int? GPUChipsetId { get; set; }

        public GPUChipset GPUChipset { get; set; }

        public int? MemoryTypeId { get; set; }

        public MemoryType MemoryType { get; set; }

        public int? MemorySize { get; set; }

        public short? MemoryInterface { get; set; }

        public byte? MemoryBandwidth { get; set; }

        public float? DirectXVersion { get; set; }

        public float? OpenGLVersion { get; set; }

        public ICollection<GPUPort> GPUPorts { get; set; }

        public short? ThermalDesignPower { get; set; }

        public string Features { get; set; }

        public float? Length { get; set; }

        public float? Height { get; set; }

        public float? SlotWidth { get; set; }

        public DateTime FirstAvailable { get; set; }
    }
}
