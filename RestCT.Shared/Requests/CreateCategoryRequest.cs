using System.ComponentModel.DataAnnotations;

namespace RestCT.Shared.Requests
{
    public class CreateCategoryRequest
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Url]
        public string? Image { get; set; }
        public CreateCategoryRequest? ParentCategory { get; set; }
    }
}
