﻿namespace PCP.Data.Models.Motherboard
{
    using PCP.Data.Common.Models;

    public class AudioChipset : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public decimal? Channels { get; set; }
    }
}
