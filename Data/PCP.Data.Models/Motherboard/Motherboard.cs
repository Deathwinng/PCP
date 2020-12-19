namespace PCP.Data.Models.Motherboard
{
    using System.Collections.Generic;

    public class Motherboard : BaseProduct
    {
        public Motherboard()
        {
            this.MotherboardMemoryType = new HashSet<MotherboardMemoryType>();
        }

        public int? SocketId { get; set; }

        public Socket Socket { get; set; }

        public int? ChipsetId { get; set; }

        public MothrboardChipset Chipset { get; set; }

        public int? MemorySlots { get; set; }

        public ICollection<MotherboardMemoryType> MotherboardMemoryType { get; set; }

        public int? MaxMemorySupport { get; set; }

        public byte? MemoryChannel { get; set; }

        public byte PCIex1 { get; set; }

        public byte PCIe3x16 { get; set; }

        public byte PCIe4x16 { get; set; }

        public byte Sata3Gbs { get; set; }

        public byte Sata6Gbs { get; set; }

        public byte Mdot2 { get; set; }

        public int? AudioChipsetId { get; set; }

        public AudioChipset AudioChipset { get; set; }

        public int? LanChipsetId { get; set; }

        public LanChipset LanChipset { get; set; }

        public string RearPanelPorts { get; set; }

        public int? FormFactorId { get; set; }

        public FormFactor FormFactor { get; set; }

        public float? Width { get; set; }

        public float? Length { get; set; }

        public string Features { get; set; }
    }
}
