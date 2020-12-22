namespace PCP.Web.ViewModels
{
    using PCP.Data.Models.Case;
    using PCP.Data.Models.CPU;
    using PCP.Data.Models.CPUCooler;
    using PCP.Data.Models.Drive;
    using PCP.Data.Models.GPU;
    using PCP.Data.Models.Memory;
    using PCP.Data.Models.Motherboard;
    using PCP.Services.Mapping;

    public class BasicInfoViewModel :
        IMapFrom<CPU>, IMapFrom<Motherboard>, IMapFrom<GPU>, IMapFrom<Memory>,
        IMapFrom<HDD>, IMapFrom<SSD>, IMapFrom<Case>, IMapFrom<CPUAirCooler>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string BrandName { get; set; }

        public string SeriesName { get; set; }

        public string Model { get; set; }

        public string ImageUrl { get; set; }

        public float Price { get; set; }
    }
}
