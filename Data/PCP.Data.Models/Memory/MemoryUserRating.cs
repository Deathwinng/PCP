namespace PCP.Data.Models.Memory
{
    using PCP.Data.Models.Rating;

    public class MemoryUserRating : UserRating
    {
        public string MemoryId { get; set; }

        public virtual Memory Memory { get; set; }
    }
}
