namespace Cyon.Domain.DTOs.Occupation
{
    public class CreateOccupationDto
    {
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public bool IsStudent { get; set; }
        public bool IsUnemployed { get; set; }
        public string CanDo { get; set; }
    }
}
