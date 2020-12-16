namespace PCP.Data.Models.GPU
{
    using PCP.Data.Common.Models;

    public class GPUInterface : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
