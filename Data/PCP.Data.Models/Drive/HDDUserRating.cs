namespace PCP.Data.Models.Drive
{
    using PCP.Data.Models.Rating;

    public class HDDUserRating : UserRating
    {
        public string HDDId { get; set; }

        public virtual HDD HDD { get; set; }
    }
}
