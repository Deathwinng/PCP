namespace PCP.Data.Models.Drive
{
    using PCP.Data.Models.Rating;

    public class SSDUserRating : UserRating
    {
        public string SSDId { get; set; }

        public virtual SSD SSD { get; set; }
    }
}
