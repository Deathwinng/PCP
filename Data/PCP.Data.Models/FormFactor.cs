﻿namespace PCP.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using PCP.Data.Common.Models;

    public class FormFactor : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
