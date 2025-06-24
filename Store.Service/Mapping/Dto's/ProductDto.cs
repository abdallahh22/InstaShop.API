using Microsoft.AspNetCore.Http;

namespace Store.Services.Mapping.Dto_s
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name_Ar { get; set; }
        public string Name_En { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool? IsUniqueProduct { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
        public string? Image_path { get; set; }
        public IFormFile Image { get; set; }
        public int? CategoryId { get; set; }
        public string? Price { get; set; }
        public string? Unit { get; set; }
    }
}