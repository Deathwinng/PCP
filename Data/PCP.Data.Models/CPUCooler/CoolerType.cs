namespace PCP.Data.Models.CPUCooler
{
    using PCP.Data.Common.Models;

    public class CoolerType : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
