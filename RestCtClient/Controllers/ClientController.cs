using Microsoft.AspNetCore.Mvc;
using RestCT.Shared.Models;
using RestCT.Shared.Requests;
using RestCT.Shared.Responses;
using RestCtClient.Interfaces;
using RestEase;

namespace RestCtClient.Controllers
{
    [ApiController]
    [Route("clientApi/items")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IPublishService _publishService;

        public ClientController(ILogger<ClientController> logger)
        {
            //_publishService = new RestClient(new HttpClient{BaseAddress = new Uri("http://localhost:7159/")}).For<IPublishService>();
            _publishService = RestClient.For<IPublishService>("http://localhost:7159");
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Item>> Get([FromQuery] FilteringParameters parameters)
        {
            return await _publishService.GetItems(parameters);
        }

        [HttpGet("categories")]
        public async Task<IEnumerable<GetCategoryResponse>> GetCategories()
        {
            return await _publishService.GetCategories();
        }
    }
}