namespace PCP.Data.Models.GPU
{
    using PCP.Data.Models.Rating;

    public class GPUUserRating : UserRating
    {
        public string GPUId { get; set; }

        public GPU GPU { get; set; }
    }
}
