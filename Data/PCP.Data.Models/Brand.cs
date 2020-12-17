﻿namespace PCP.Data.Models
{
    using PCP.Data.Common.Models;

    public class Brand : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}