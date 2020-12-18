namespace PCP.Data.Models.HDD
{
    using System;

    using PCP.Data.Common.Models;
    using PCP.Data.Models.Enums;

    public class HDD : BaseDeletableModel<int>
    {
        public string Model { get; set; }

        public float? Price { get; set; }

        public string ImageUrl { get; set; }

        public int? BrandId { get; set; }

        public Brand Brand { get; set; }

        public int? SeriesId { get; set; }

        public Series Series { get; set; }

        public Category Category { get; set; }

        public int? InterfaceId { get; set; }

        public Interface Interface { get; set; }

        public short? CapacityGb { get; set; }

        public short? RevolutionsPerMinute { get; set; }

        public int? CacheKb { get; set; }

        public string Features { get; set; }

        public HDDUsage Usage { get; set; }

        public FormFactor FormFactor { get; set; }

        public float? Height { get; set; }

        public float? Width { get; set; }

        public float? Length { get; set; }

        public DateTime FirstAvailable { get; set; }
    }
}
