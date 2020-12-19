namespace PCP.Data.Models.DiskDrive
{
    public class SSD : BaseDrive
    {
        public int? MemoryComponentId { get; set; }

        public MemoryComponent MemoryComponent { get; set; }

        public short? MaxSequentialReadMBps { get; set; }

        public short? MaxSequentialWriteMBps { get; set; }

        public string FourKBRandomRead { get; set; }

        public string FourKBRandomWrite{ get; set; }

        public int? MeanTimeBetweenFailures { get; set; }

        public string IdlePowerComsumtion { get; set; }

        public string ActivePowerConsumption { get; set; }
    }
}
