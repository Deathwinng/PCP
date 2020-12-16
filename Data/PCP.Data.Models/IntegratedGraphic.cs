namespace PCP.Data.Models
{
    using PCP.Data.Common.Models;

    public class IntegratedGraphic : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public short? BaseFrequency { get; set; }

        public short? MaxFrequency { get; set; }
    }
}
