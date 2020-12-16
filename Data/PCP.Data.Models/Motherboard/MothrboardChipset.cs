namespace PCP.Data.Models.Motherboard
{
    using PCP.Data.Common.Models;

    public class MothrboardChipset : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
