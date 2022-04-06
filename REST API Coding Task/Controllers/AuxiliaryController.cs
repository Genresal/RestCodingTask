using Microsoft.AspNetCore.Mvc;
using RestCT.BusinessLogic.Services.Interfaces;
using RestCT.Shared.Models;

namespace REST_API_Coding_Task.Controllers
{
    [ApiController]
    [Route("api/service")]
    public class AuxiliaryController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IAuxiliaryService _service;

        public AuxiliaryController(ILogger<ItemController> logger, IAuxiliaryService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("addDefaultData")]
        public async Task<IActionResult> Create()
        {
            await _service.AddDefaultData();

            return NoContent();
        }

        [HttpDelete("clear")]
        public IActionResult Clear()
        {
            _service.Clear();

            return NoContent();
        }
    }
}