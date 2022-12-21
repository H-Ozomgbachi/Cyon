namespace Cyon.Domain.Entities
{
    public class Meeting : BaseEntity
    {
        public DateTime Date { get; set; }
        public ICollection<Agendum> Agenda { get; set; }
        public double ProposedDurationInMinutes { get; set; }
        public Guid ModifiedBy { get; set; }
    }

    public class Agendum : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Meeting Meeting { get; set; }
    }
}
