namespace PCP.Web.ViewModels
{
    public class SpecsTableRowPartialBoolViewModel : BaseSpecsTableRowPartialViewModel
    {
        public bool? BoolValue { get; set; }

        public string Value
        {
            get
            {
                if (this.BoolValue == true)
                {
                    return "Yes";
                }

                return "No";
            }
        }
    }
}
