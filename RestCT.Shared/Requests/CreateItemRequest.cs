using System.ComponentModel.DataAnnotations;

namespace RestCT.Shared.Requests
{
    public class CreateItemRequest
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Url]
        public string? Image { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public uint Amount { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
