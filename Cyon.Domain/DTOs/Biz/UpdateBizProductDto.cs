namespace Cyon.Domain.DTOs.Biz
{
    public class UpdateBizProductDto
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public bool IsApproved { get; set; }
        public int TotalSales { get; set; }
        public uint AvgRating { get; set; }
        public int TotalRating { get; set; }
    }
}
