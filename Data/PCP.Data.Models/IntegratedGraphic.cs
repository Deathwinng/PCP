namespace PCP.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using PCP.Data.Common.Models;

    public class IntegratedGraphic : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public short? BaseFrequency { get; set; }

        public short? MaxFrequency { get; set; }
    }
}
