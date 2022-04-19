namespace RestCT.Shared.Responses
{
    public class GetItemResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public uint Amount { get; set; }
        public int CategoryId { get; set; }
    }
}
