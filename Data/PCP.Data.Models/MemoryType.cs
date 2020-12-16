namespace PCP.Data.Models
{
    using PCP.Data.Common.Models;

    public class MemoryType : BaseDeletableModel<int>
    {
        public string Type { get; set; }
    }
}
