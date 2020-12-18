namespace PCP.Data.Models
{
    using PCP.Data.Common.Models;

    public class Interface : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
