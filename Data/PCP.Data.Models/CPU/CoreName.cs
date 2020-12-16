namespace PCP.Data.Models
{
    using PCP.Data.Common.Models;

    public class CoreName : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
