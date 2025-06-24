namespace Store.Data.Entities
{
    public class StoreType : BaseEntity
    {
        public bool? IsActive { get; set; }
        public string? Icon_path { get; set; }
        public ICollection<store> stores { get; set; }
    }
}