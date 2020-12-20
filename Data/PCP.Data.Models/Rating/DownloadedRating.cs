namespace PCP.Data.Models.Rating
{
    using System.ComponentModel.DataAnnotations;

    using PCP.Data.Common.Models;

    public class DownloadedRating : BaseDeletableModel<int>
    {
        [Required]
        public string ProductId { get; set; }

        public int OneStarVotes { get; set; }

        public int TwoStarVotes { get; set; }

        public int ThreeStarVotes { get; set; }

        public int FourStarVotes { get; set; }

        public int FiveStarVotes { get; set; }
    }
}
