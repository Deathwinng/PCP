namespace PCP.Data.Models.Drive
{
    using PCP.Data.Models.Rating;

    public class HDDUserRating : UserRating
    {
        public string HDDId { get; set; }

        public HDD HDD { get; set; }
    }
}
