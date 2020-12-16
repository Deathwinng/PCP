using PCP.Data.Common.Models;

namespace PCP.Data.Models.GPU
{
    public class MemoryBandwidth : BaseDeletableModel<int>
    {
        public decimal? Bandwidth { get; set; }
    }
}
