namespace PCP.Data.Models
{
    using PCP.Data.Common.Models;

    public class Port : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
