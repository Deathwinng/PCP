namespace PCP.Services
{
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    using AngleSharp;
    using AngleSharp.Dom;
    using PCP.Data.Models.Enums;

    public class NeweggProductScrapperBaseService
    {
        private readonly IConfiguration configuration;

        public NeweggProductScrapperBaseService()
        {
            this.configuration = Configuration.Default.WithDefaultLoader();
            this.Context = BrowsingContext.New(this.configuration);
            this.MatchOneOrMoreDigits = new Regex(@"\d+");
            this.MatchOneOrMoreDigitsFloat = new Regex(@"\d+\.?\d?");
        }

        public IBrowsingContext Context { get; set; }

        public Regex MatchOneOrMoreDigits { get; set; }

        public Regex MatchOneOrMoreDigitsFloat { get; set; }

        public Category GetCategoryFromUrl(string productUrl)
        {
            var productUrlLower = productUrl.ToLower();
            if (productUrlLower.Contains("desktop"))
            {
                return Category.Desktop;
            }

            if (productUrlLower.Contains("server"))
            {
                return Category.Server;
            }

            if (productUrlLower.Contains("workstation"))
            {
                return Category.Workstation;
            }

            if (productUrlLower.Contains("mobile") || productUrlLower.Contains("laptop"))
            {
                return Category.Mobile;
            }

            return Category.Desktop;
        }

        public float? MatchAndParseFloat(string stringToParse)
        {
            var match = this.MatchOneOrMoreDigitsFloat.Match(stringToParse);
            if (!match.Success)
            {
                return null;
            }

            return float.Parse(match.Value, CultureInfo.InvariantCulture);
        }

        public string GetImageUrl(IDocument document)
        {
            return document.QuerySelector("#side-swiper-container .swiper-slide[style=\"order:-1\"] img")?.GetAttribute("src");
        }

        public IHtmlCollection<IElement> GetAllTablesRows(IDocument document)
        {
            return document.QuerySelectorAll("#product-details .tab-panes .tab-pane .table-horizontal tbody tr");
        }

        public IHtmlCollection<IElement> GetAllTables(IDocument document)
        {
            return document.QuerySelectorAll("#product-details .tab-panes .tab-pane .table-horizontal");
        }

        public float? GetPrice(IDocument document)
        {
            var priceAsString = document.QuerySelectorAll(".product-pane .product-price .price .price-current")
                .LastOrDefault()?.TextContent.Replace("$", string.Empty).Replace(",", string.Empty);
            float.TryParse(priceAsString, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out float price);
            return price;
        }

        public short GetFrecuencyAsShort(string frequencyAsString)
        {
            if (frequencyAsString.Contains("Boost"))
            {
                frequencyAsString = frequencyAsString.Replace("Intel Turbo Boost 2.0 Max Technology Frequency:", string.Empty);
            }

            var match = this.MatchOneOrMoreDigitsFloat.Match(frequencyAsString);
            var value = match.Value;
            var floatResult = float.Parse(value, CultureInfo.InvariantCulture);
            var isInGigahertz = frequencyAsString.ToLower().Contains("ghz");
            if (isInGigahertz)
            {
                floatResult *= 1000;
            }

            var result = (short)floatResult;
            return result;
        }
    }
}
