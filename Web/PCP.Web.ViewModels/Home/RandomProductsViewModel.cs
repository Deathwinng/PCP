namespace PCP.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using PCP.Data.Models.Case;
    using PCP.Data.Models.CPU;
    using PCP.Data.Models.CPUCooler;
    using PCP.Data.Models.Drive;
    using PCP.Data.Models.GPU;
    using PCP.Data.Models.Memory;
    using PCP.Data.Models.Motherboard;

    public class RandomProductsViewModel
    {
        public IEnumerable<BasicInfoViewModel> CPUs { get; set; }

        public IEnumerable<BasicInfoViewModel> Motherboards { get; set; }

        public IEnumerable<BasicInfoViewModel> GPUs { get; set; }

        public IEnumerable<BasicInfoViewModel> Memories { get; set; }

        public IEnumerable<BasicInfoViewModel> HDDs { get; set; }

        public IEnumerable<BasicInfoViewModel> SSDs { get; set; }

        public IEnumerable<BasicInfoViewModel> CPUAirCoolers { get; set; }

        public IEnumerable<BasicInfoViewModel> Cases { get; set; }
    }
}
