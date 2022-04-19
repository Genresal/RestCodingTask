using RestCT.Shared.Models;
using RestCT.Shared.Requests;
using RestCT.Shared.Responses;
using RestEase;

namespace RestCtClient.Interfaces
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized, Body = BodySerializationMethod.Serialized)]
    public interface IPublishService
    {
        [AllowAnyStatusCode]
        [Get("https://localhost:7159/api/items")]
        Task<IEnumerable<Item>> GetItems([Query] FilteringParameters parameters);

        [AllowAnyStatusCode]
        [Get("https://localhost:7159/api/categories")]
        Task<IEnumerable<GetCategoryResponse>> GetCategories();
    }
}
