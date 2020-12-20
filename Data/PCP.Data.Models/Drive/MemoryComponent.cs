namespace PCP.Data.Models.Drive
{
    using PCP.Data.Common.Models;

    public class MemoryComponent : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
