using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestCT.Shared.Models;
using RestCT.Shared.Requests;
using RestEase;

namespace RestCtClient.Interfaces
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized, Body = BodySerializationMethod.Serialized)]
    public interface IPublishService
    {
        [AllowAnyStatusCode]
        [Get("api/items")]
        Task <IEnumerable<Item>> GetItems([Query] FilteringParameters parameters);

        [AllowAnyStatusCode]
        [Get("api/categories")]
        Task<IEnumerable<Category>> GetCategories();
    }
}
