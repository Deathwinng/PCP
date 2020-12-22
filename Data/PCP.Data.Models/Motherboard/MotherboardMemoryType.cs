namespace PCP.Data.Models.Motherboard
{
    using PCP.Data.Common.Models;

    public class MotherboardMemoryType : BaseDeletableModel<int>
    {
        public string MotherboardId { get; set; }

        public virtual Motherboard Motherboard { get; set; }

        public int MemoryTypeId { get; set; }

        public virtual MemoryType MemoryType { get; set; }

        public int? MemorySpeedId { get; set; }

        public virtual MemorySpeed MemorySpeed { get; set; }
    }
}
