using Microsoft.AspNetCore.Mvc;
using RestCT.BusinessLogic.Services.Interfaces;
using RestCT.Shared.Models;

namespace REST_API_Coding_Task.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _service;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category request)
        {
            await _service.CreateCategory(request);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Category request)
        {
            await _service.UpdateCategory(request);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetCategories());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteCategory(id);

            return NoContent();
        }
    }
}