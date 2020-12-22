namespace PCP.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using PCP.Data.Common.Models;

    public class Interface : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
