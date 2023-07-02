namespace Cyon.Domain.DTOs.UpcomngEvent
{
    public class UpdateUpcomingEventDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
