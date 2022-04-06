using System.ComponentModel.DataAnnotations;

namespace RestCT.Shared.Models
{
    public class Category
    {
        public Category()
        {
            Items = new List<Item>();
        }
        public  int Id { get; set; }
        [Required] 
        [MaxLength(50)]
        public string Name { get; set; }
        [Url]
        public string? Image { get; set; }
        public Category? ParentCategory { get; set; }

        public ICollection<Item> Items { get; set; }
    }

}
