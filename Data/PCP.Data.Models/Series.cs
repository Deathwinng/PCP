namespace PCP.Data.Models
{
    using PCP.Data.Common.Models;

    public class Series : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
