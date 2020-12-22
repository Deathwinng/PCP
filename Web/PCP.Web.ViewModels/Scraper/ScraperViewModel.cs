namespace PCP.Web.ViewModels.Scraper
{
    using System.Collections.Generic;

    public class ScraperViewModel
    {
        public ScraperViewModel()
        {
            this.Messages = new List<ScraperViewModelMessage>();
        }

        public int NumberOfSuccessfullyAdded { get; set; }

        public int NumberOfErrors { get; set; }

        public ICollection<ScraperViewModelMessage> Messages { get; set; }
    }
}
