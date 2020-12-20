namespace PCP.Data.Models
{
    using PCP.Data.Common.Models;

    public class Color : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
