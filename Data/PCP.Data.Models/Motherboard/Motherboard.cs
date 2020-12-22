namespace PCP.Data.Models.Motherboard
{
    using System.Collections.Generic;

    public class Motherboard : BaseProduct
    {
        public Motherboard()
        {
            this.MotherboardMemoryType = new HashSet<MotherboardMemoryType>();
            this.UserRatings = new HashSet<MotherboardUserRating>();
        }

        public virtual ICollection<MotherboardUserRating> UserRatings { get; set; }

        public int? SocketId { get; set; }

        public virtual Socket Socket { get; set; }

        public int? ChipsetId { get; set; }

        public virtual MothrboardChipset Chipset { get; set; }

        public int? MemorySlots { get; set; }

        public virtual ICollection<MotherboardMemoryType> MotherboardMemoryType { get; set; }

        public int? MaxMemorySupport { get; set; }

        public byte? MemoryChannel { get; set; }

        public byte PCIex1 { get; set; }

        public byte PCIe3x16 { get; set; }

        public byte PCIe4x16 { get; set; }

        public byte Sata3Gbs { get; set; }

        public byte Sata6Gbs { get; set; }

        public byte Mdot2 { get; set; }

        public int? AudioChipsetId { get; set; }

        public virtual AudioChipset AudioChipset { get; set; }

        public int? LanChipsetId { get; set; }

        public virtual LanChipset LanChipset { get; set; }

        public string RearPanelPorts { get; set; }

        public int? FormFactorId { get; set; }

        public virtual FormFactor FormFactor { get; set; }

        public float? Width { get; set; }

        public float? Length { get; set; }

        public string Features { get; set; }
    }
}
