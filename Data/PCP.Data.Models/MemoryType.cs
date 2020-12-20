namespace PCP.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using PCP.Data.Common.Models;

    public class MemoryType : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Type { get; set; }
    }
}
