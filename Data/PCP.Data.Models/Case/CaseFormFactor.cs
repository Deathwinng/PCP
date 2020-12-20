namespace PCP.Data.Models.Case
{
    using PCP.Data.Common.Models;

    public class CaseFormFactor : BaseDeletableModel<int>
    {
        public string CaseId { get; set; }

        public Case Case { get; set; }

        public int FormFactorId { get; set; }

        public FormFactor FormFactor { get; set; }
    }
}
