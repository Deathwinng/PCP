namespace PCP.Data.Models.Drive
{
    using System.ComponentModel.DataAnnotations;

    using PCP.Data.Common.Models;

    public class DiskForUsage : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
