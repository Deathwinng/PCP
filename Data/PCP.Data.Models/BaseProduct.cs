namespace PCP.Data.Models
{
    using System;

    using PCP.Data.Common.Models;
    using PCP.Data.Models.Enums;

    public class BaseProduct : BaseDeletableModel<string>
    {
        public BaseProduct()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Model { get; set; }

        public float? Price { get; set; }

        public string ImageUrl { get; set; }

        public int? BrandId { get; set; }

        public Brand Brand { get; set; }

        public int? SeriesId { get; set; }

        public Series Series { get; set; }

        public Category Category { get; set; }

        public DateTime? FirstAvailable { get; set; }
    }
}
