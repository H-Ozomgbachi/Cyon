namespace Cyon.Domain.Models.Meeting
{
    public class MeetingModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<AgendumModel> Agenda { get; set; }
        public double ProposedDurationInMinutes { get; set; }
    }

    public class AgendumModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
