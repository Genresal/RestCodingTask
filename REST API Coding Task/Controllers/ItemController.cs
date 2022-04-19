using Microsoft.AspNetCore.Mvc;
using RestCT.BusinessLogic.Services.Interfaces;
using RestCT.Shared.Requests;

namespace REST_API_Coding_Task.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IItemService _service;

        public ItemController(ILogger<ItemController> logger, IItemService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemRequest request)
        {
            var createdItem = await _service.CreateItem(request);
            _logger.LogInformation("Created new category: ", createdItem);

            return Ok(createdItem);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CreateItemRequest request)
        {
            await _service.UpdateItem(request);
            _logger.LogInformation("Updated category: ", request);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FilteringParameters parameters)
        {
            return Ok(await _service.GetItems(parameters));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetItemById(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteItem(id);
            _logger.LogInformation("Deleted category with id: " + id.ToString());

            return Ok();
        }
    }
}