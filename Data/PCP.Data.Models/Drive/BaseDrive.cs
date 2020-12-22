namespace PCP.Data.Models.Drive
{
    public abstract class BaseDrive : BaseProduct
    {
        public int? InterfaceId { get; set; }

        public virtual Interface Interface { get; set; }

        public short? CapacityGb { get; set; }

        public int? CacheKb { get; set; }

        public string Features { get; set; }

        public virtual DiskForUsage Usage { get; set; }

        public virtual FormFactor FormFactor { get; set; }

        public float? Height { get; set; }

        public float? Width { get; set; }

        public float? Length { get; set; }
    }
}
