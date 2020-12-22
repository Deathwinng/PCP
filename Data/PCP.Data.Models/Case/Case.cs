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

        public virtual ICollection<CaseUserRating> UserRatings { get; set; }

        public int? CaseTypeId { get; set; }

        public virtual CaseType CaseType { get; set; }

        public int? ColorId { get; set; }

        public virtual Color Color { get; set; }

        public virtual ICollection<CaseMaterial> CaseMaterials { get; set; }

        public bool? HasPowerSupply { get; set; }

        public virtual CasePowerSupplyPosition CasePowerSupplyPosition { get; set; }

        public virtual ICollection<CaseFormFactor> CaseFormFactors { get; set; }

        public bool? SidePanelWindow { get; set; }

        public string DustFilters { get; set; }

        public byte? DriveBay2point5 { get; set; }

        public byte? DriveBay3point5 { get; set; }

        public byte? ExpansionSlots { get; set; }

        public string FrontPorts { get; set; }

        public string FanOptions { get; set; }

        public string RadioatorOptions { get; set; }

        public short? MaxGPULength { get; set; }

        public short? MaxCPUCoolerHeight { get; set; }

        public short? MaxPSULenght { get; set; }

        public float? Height { get; set; }

        public float? Width { get; set; }

        public float? Depth { get; set; }

        public float? Weight { get; set; }

        public string Features { get; set; }
    }
}
