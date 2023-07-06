namespace Cyon.Domain.Models.YearProgramme
{
    public class YearProgrammeModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImageUrl { get; set; }
        public string Scope { get; set; }
        public string Year { get; set; }
    }
}
