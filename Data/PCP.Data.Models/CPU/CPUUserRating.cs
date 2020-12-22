namespace PCP.Data.Models.CPU
{
    using PCP.Data.Models.Rating;

    public class CPUUserRating : UserRating
    {
        public string CPUId { get; set; }

        public virtual CPU CPU { get; set; }
    }
}
