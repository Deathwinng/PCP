namespace PCP.Data.Models.Drive
{
    using System.Collections.Generic;

    public class HDD : BaseDrive
    {
        public HDD()
        {
            this.UserRatings = new HashSet<HDDUserRating>();
        }

        public ICollection<HDDUserRating> UserRatings { get; set; }

        public short? RevolutionsPerMinute { get; set; }
    }
}
