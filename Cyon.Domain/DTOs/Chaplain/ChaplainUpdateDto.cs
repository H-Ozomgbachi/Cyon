using System.Text.Json.Serialization;

namespace Cyon.Domain.DTOs.Chaplain
{
    public class ChaplainUpdateDto
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string ImageUrl { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        [JsonIgnore]
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    }
}
