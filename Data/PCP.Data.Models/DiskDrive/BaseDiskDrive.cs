namespace PCP.Data.Models
{
    public class BaseDiskDrive : BaseProduct
    {
        public int? InterfaceId { get; set; }

        public Interface Interface { get; set; }

        public short? CapacityGb { get; set; }

        public int? CacheKb { get; set; }

        public string Features { get; set; }

        public DiskForUsage Usage { get; set; }

        public FormFactor FormFactor { get; set; }

        public float? Height { get; set; }

        public float? Width { get; set; }

        public float? Length { get; set; }
    }
}
