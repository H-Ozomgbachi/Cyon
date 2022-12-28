using System.Text.Json.Serialization;

namespace Cyon.Domain.DTOs.AccountManagement
{
    public class RequestToDeactivateDto
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public string Reason { get; set; }
    }
}
