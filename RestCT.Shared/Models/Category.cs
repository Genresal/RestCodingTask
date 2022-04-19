namespace RestCT.Shared.Models
{
    public class Category : BaseModel
    {
        public Category()
        {
            Items = new List<Item>();
        }
        public string Name { get; set; }
        public string? Image { get; set; }
        public Category? ParentCategory { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
