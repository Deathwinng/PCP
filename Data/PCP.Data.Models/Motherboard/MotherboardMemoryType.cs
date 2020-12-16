namespace PCP.Data.Models.Motherboard
{
    using PCP.Data.Common.Models;

    public class MotherboardMemoryType : BaseDeletableModel<int>
    {
        public int MotherboardId { get; set; }

        public Motherboard Motherboard { get; set; }

        public int MemoryTypeId { get; set; }

        public MemoryType MemoryType { get; set; }

        public int? MemorySpeedId { get; set; }

        public MemorySpeed MemorySpeed { get; set; }
    }
}
