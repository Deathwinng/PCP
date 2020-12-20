namespace PCP.Data.Models.Case
{
    using PCP.Data.Models.Rating;

    public class CaseUserRating : UserRating
    {
        public string CaseId { get; set; }

        public Case Case { get; set; }
    }
}
