namespace PCP.Data.Models.Case
{
    using System.Collections.Generic;

    using PCP.Data.Models.Enums;

    public class Case : BaseProduct
    {
        public Case()
        {
            this.CaseMaterials = new HashSet<CaseMaterial>();
            this.CaseFormFactors = new HashSet<CaseFormFactor>();
            this.UserRatings = new HashSet<CaseUserRating>();
        }

        public ICollection<CaseUserRating> UserRatings { get; set; }

        public int? CaseTypeId { get; set; }

        public CaseType CaseType { get; set; }

        public int? ColorId { get; set; }

        public Color Color { get; set; }

        public ICollection<CaseMaterial> CaseMaterials { get; set; }

        public bool? HasPowerSupply { get; set; }

        public CasePowerSupplyPosition CasePowerSupplyPosition { get; set; }

        public ICollection<CaseFormFactor> CaseFormFactors { get; set; }

        public bool? SidePanelWindow { get; set; }

        public string DustFilters { get; set; }

        public byte? DriveBay2point5 { get; set; }

        public byte? DriveBay3point5 { get; set; }

        public byte? ExpansionSlots { get; set; }

        public string FrontPorts { get; set; }

        public string FanOptions { get; set; }

        public string RadioatorOptions { get; set; }

        public short? MaxGPULength { get; set; }

        public byte? MaxCPUCoolerHeight { get; set; }

        public byte? MaxPSULenght { get; set; }

        public float? Height { get; set; }

        public float? Width { get; set; }

        public float? Depth { get; set; }

        public float? Weight { get; set; }

        public string Features { get; set; }
    }
}
