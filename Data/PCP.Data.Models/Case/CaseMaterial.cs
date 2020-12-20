namespace PCP.Data.Models.Case
{
    using PCP.Data.Common.Models;

    public class CaseMaterial : BaseDeletableModel<int>
    {
        public string CaseId { get; set; }

        public Case Case { get; set; }

        public int MaterialId { get; set; }

        public Material Material { get; set; }
    }
}
