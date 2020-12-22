using System.Collections.Generic;

namespace PCP.Data.Models.Drive
{
    public class SSD : BaseDrive
    {
        public SSD()
        {
            this.UserRatings = new HashSet<SSDUserRating>();
        }

        public virtual ICollection<SSDUserRating> UserRatings { get; set; }

        public int? MemoryComponentId { get; set; }

        public virtual MemoryComponent MemoryComponent { get; set; }

        public short? MaxSequentialReadMBps { get; set; }

        public short? MaxSequentialWriteMBps { get; set; }

        public string FourKBRandomRead { get; set; }

        public string FourKBRandomWrite{ get; set; }

        public int? MeanTimeBetweenFailures { get; set; }

        public string IdlePowerComsumtion { get; set; }

        public string ActivePowerConsumption { get; set; }
    }
}
