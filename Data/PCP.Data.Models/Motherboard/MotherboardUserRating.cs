﻿namespace PCP.Data.Models.Motherboard
{
    using PCP.Data.Models.Rating;

    public class MotherboardUserRating : UserRating
    {
        public string MotherboardId { get; set; }

        public virtual Motherboard Motherboard { get; set; }
    }
}
