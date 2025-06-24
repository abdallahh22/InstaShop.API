namespace Store.Services.Mapping.Dto_s
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Name_Ar { get; set; }
        public string Name_En { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? StoreId { get; set; }
        public string? Icon_path { get; set; }
        public ICollection<ProductDto> Products { get; set; }
    }
}