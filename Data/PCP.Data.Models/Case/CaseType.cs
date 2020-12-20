namespace PCP.Data.Models.Case
{
    using PCP.Data.Common.Models;

    public class CaseType : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
