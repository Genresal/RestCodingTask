using Microsoft.AspNetCore.Mvc;
using RestCT.BusinessLogic.Services.Interfaces;
using RestCT.Shared.Requests;

namespace REST_API_Coding_Task.Controllers
{
    [ApiController]
    //    [Route("api/categories/4/items/8")]
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

        //todo
        //create requests!!
        //custom responce!!
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryRequest request)
        {
            var createdCategory = await _service.CreateCategory(request);
            _logger.LogInformation("Created new category: ", createdCategory);

            //todo
            //return ok
            //return created entity!!!
            return Ok(createdCategory);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CreateCategoryRequest request)
        {
            await _service.UpdateCategory(request);
            _logger.LogInformation("Updated category: ", request);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetCategories());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetCategoryById(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteCategory(id);
            _logger.LogInformation("Deleted category with id: " + id.ToString());

            return Ok();
        }
    }
}