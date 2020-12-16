namespace PCP.Data.Models.GPU
{
    using PCP.Data.Common.Models;

    public class GPUCore : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public int? SeriesId { get; set; }

        public Series Series { get; set; }

        public short? Cores { get; set; }
    }
}
