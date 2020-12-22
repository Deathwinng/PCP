namespace PCP.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using PCP.Data.Common.Models;

    public class Material : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
