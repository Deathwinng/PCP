namespace PCP.Data.Models.GPU
{
    using PCP.Data.Models.Rating;

    public class GPUUserRating : UserRating
    {
        public string GPUId { get; set; }

        public virtual GPU GPU { get; set; }
    }
}
