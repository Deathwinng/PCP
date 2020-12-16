namespace PCP.Data.Models.GPU
{
    using PCP.Data.Common.Models;

    public class GPUChipset : BaseDeletableModel<int>
    {
        public int? GPUCoreId { get; set; }

        public GPUCore GPUCore { get; set; }

        public short? CoreClock { get; set; }

        public short? TurboClock { get; set; }
    }
}
