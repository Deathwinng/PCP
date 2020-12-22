namespace PCP.Web.ViewModels.CPUs
{
    using System.Collections.Generic;

    public class CPUsViewModel
    {
        public IEnumerable<BasicInfoViewModel> CPUs { get; set; }

        public PagingViewModel PagingViewModel { get; set; }
    }
}
