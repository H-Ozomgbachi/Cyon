namespace Cyon.Domain.Models.Biz
{
    public class BizProductModel
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public bool IsApproved { get; set; } = false;
        public bool IsLocked { get; set; } = false;
        public int TotalSales { get; set; }
        public uint AvgRating { get; set; }
        public int TotalRating { get; set; }
        public Guid BizId { get; set; }
    }
}
