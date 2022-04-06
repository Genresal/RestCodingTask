using Microsoft.AspNetCore.Mvc;
using RestCT.BusinessLogic.Services.Interfaces;
using RestCT.Shared.Models;
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
        public async Task<IActionResult> Create(Item request)
        {
            await _service.CreateItem(request);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Item request)
        {
            await _service.UpdateItem(request);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FilteringParameters parameters)
        {
            return Ok(await _service.GetItems(parameters));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteItem(id);

            return NoContent();
        }
    }
}