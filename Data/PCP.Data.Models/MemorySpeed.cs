namespace PCP.Data.Models
{
    using PCP.Data.Common.Models;

    public class MemorySpeed : BaseDeletableModel<int>
    {
        public short? Speed { get; set; }
    }
}
