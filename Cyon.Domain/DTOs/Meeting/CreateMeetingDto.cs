namespace Cyon.Domain.DTOs.Meeting
{
    public class CreateMeetingDto
    {
        public DateTime Date { get; set; }
        public double ProposedDurationInMinutes { get; set; }
        public IEnumerable<CreateAgendumDto> Agenda { get; set; }
    }

    public class CreateAgendumDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
