namespace PCP.Data.Models.GPU
{
    using System.Collections.Generic;

    public class GPU : BaseProduct
    {
        public GPU()
        {
            this.GPUPorts = new HashSet<GPUPort>();
            this.UserRatings = new HashSet<GPUUserRating>();
        }

        public ICollection<GPUUserRating> UserRatings { get; set; }

        public int? GPUInterfaceId { get; set; }

        public Interface GPUInterface { get; set; }

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
    }
}
