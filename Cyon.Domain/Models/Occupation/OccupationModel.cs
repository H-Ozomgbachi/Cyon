namespace Cyon.Domain.Models.Occupation
{
    public class OccupationModel
    {
        public Guid Id { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public bool IsStudent { get; set; }
        public bool IsUnemployed { get; set; }
        public string CanDo { get; set; }
    }
}
