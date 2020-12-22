namespace PCP.Data.Models.GPU
{
    using PCP.Data.Common.Models;

    public class GPUCore : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        public int? SeriesId { get; set; }

        public virtual Series Series { get; set; }

        public short? Cores { get; set; }
    }
}
