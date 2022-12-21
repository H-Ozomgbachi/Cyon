namespace Cyon.Domain.DTOs.Meeting
{
    public class UpdateMeetingDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public double ProposedDurationInMinutes { get; set; }
        public IEnumerable<UpdateAgendumDto> Agenda { get; set; }
    }

    public class UpdateAgendumDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
