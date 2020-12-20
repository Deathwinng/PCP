namespace PCP.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using PCP.Data.Common.Models;
    using PCP.Data.Models.Enums;
    using PCP.Data.Models.Rating;

    public class BaseProduct : BaseDeletableModel<string>
    {
        public BaseProduct()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Model { get; set; }

        public float? Price { get; set; }

        public int? DownloadedRatingId { get; set; }

        public DownloadedRating DownloadedRating { get; set; }

        public string ImageUrl { get; set; }

        public int? BrandId { get; set; }

        public Brand Brand { get; set; }

        public int? SeriesId { get; set; }

        public Series Series { get; set; }

        public Category Category { get; set; }

        public DateTime? FirstAvailable { get; set; }
    }
}
