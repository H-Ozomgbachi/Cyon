namespace Cyon.Domain.Models.Decision
{
    public class DecisionResultModel
    {
        public string Response { get; set; }
        public int NumberOfVotes { get; set; }
        public DateTime LatestVoteTime { get; set; }
    }
}
