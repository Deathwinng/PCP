namespace PCP.Data.Models.Rating
{
    using PCP.Data.Common.Models;

    public class UserRating : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public byte Rating { get; set; }
    }
}
