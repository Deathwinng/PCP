namespace PCP.Data.Models.GPU
{
    using PCP.Data.Common.Models;

    public class GPUPort : BaseDeletableModel<int>
    {
        public int GPUId { get; set; }

        public GPU GPU { get; set; }

        public int PortId { get; set; }

        public Port Port { get; set; }

        public byte Quantity { get; set; }
    }
}
