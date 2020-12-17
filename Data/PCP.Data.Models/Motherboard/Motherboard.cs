namespace PCP.Data.Models.Motherboard
{
    using System;
    using System.Collections.Generic;

    using PCP.Data.Common.Models;

    public class Motherboard : BaseDeletableModel<int>
    {
        public Motherboard()
        {
            this.MotherboardMemoryType = new HashSet<MotherboardMemoryType>();
        }

        public float? Price { get; set; }

        public string ImageUrl { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public string Model { get; set; }

        public int? SeriesId { get; set; }

        public Series Series { get; set; }

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

        public DateTime? FirstAvailable { get; set; }
    }
}
