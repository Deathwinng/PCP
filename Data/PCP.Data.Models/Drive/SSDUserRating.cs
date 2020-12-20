namespace PCP.Data.Models.Drive
{
    using PCP.Data.Models.Rating;

    public class SSDUserRating : UserRating
    {
        public string SSDId { get; set; }

        public SSD SSD { get; set; }
    }
}
