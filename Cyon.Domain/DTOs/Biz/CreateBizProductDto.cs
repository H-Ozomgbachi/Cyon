using Microsoft.AspNetCore.Http;

namespace Cyon.Domain.DTOs.Biz
{
    public class CreateBizProductDto
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Img { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }

        public Guid BizId { get; set; }
    }
}
