namespace Store.Services.Mapping.Dto_s
{
    public class RateDto
    {
        public int Id { get; set; }
        public string? AppUserId { get; set; }
        public decimal Rating { get; set; }
        public string Comment { get; set; }
    }
}