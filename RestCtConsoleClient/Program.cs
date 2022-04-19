// See https://aka.ms/new-console-template for more information

using RestCT.Shared.Models;
using RestCT.Shared.Responses;


using (var client = new HttpClient())
{
    var request = new HttpRequestMessage(new HttpMethod("GET"), "https://localhost:7159/api/categories");

    //request.Headers.TryAddWithoutValidation("X-Auth-Token", "LocalTocken");
    //request.Headers.TryAddWithoutValidation("X-User-Id", "LocalID");

    HttpResponseMessage response = await client.SendAsync(request);

    if (response.IsSuccessStatusCode)
    {
        var readTask = response.Content.ReadAsAsync<GetCategoryResponse[]>();
        readTask.Wait();

        var categories = readTask.Result;

        foreach (var category in categories)
        {
            Console.WriteLine($"{category.Id} {category.Name}");
        }
    }

    Console.ReadLine();
}
