namespace RestCT.Shared.Models
{
    public class Item : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public uint Amount { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }

}
