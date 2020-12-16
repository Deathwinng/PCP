namespace PCP.Data.Models.GPU
{
    using PCP.Data.Common.Models;

    public class GPU : BaseDeletableModel<int>
    {
        public decimal? Price { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public string Model { get; set; }

        public int? SeriesId { get; set; }

        public Series Series { get; set; }

        public int? GPUInterfaceId { get; set; }

        public GPUInterface GPUInterface { get; set; }

        public int? GPUChipsetId { get; set; }

        public GPUChipset GPUChipset { get; set; }

        public int MyProperty { get; set; }
    }
}
