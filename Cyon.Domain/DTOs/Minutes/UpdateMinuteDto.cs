namespace Cyon.Domain.DTOs.Minutes
{
    public class UpdateMinuteDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime DateOfMeeting { get; set; }
    }
}
