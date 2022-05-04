using ExamProject.Data.ViewModel;
using ExamProject.Services.CategoryS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ExamProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoriesService _categoriesService { get; set; }
        private ILogger<NewsController> _logger { get; set; }
        public CategoriesController(ICategoriesService categoriesService, ILogger<NewsController> logger)
        {
            _categoriesService = categoriesService;
            _logger = logger;
        }

        [HttpPost("add-category")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryVM category)
        {
            try
            {
                await _categoriesService.AddCategory(category);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-categories")]
        public async Task<IActionResult> GetAllNews()
        {
            try
            {
                var _categories = _categoriesService.GetAllCategories();
                return Ok(await _categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-category-by-id/{id}")]
        public async Task<IActionResult> UpdateNewsById(int id, [FromBody] CategoryVM category)
        {
            try
            {
                var _news =_categoriesService.UpdateNewsById(id, category);
                return Ok(await _news);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-news-by-id")]
        public IActionResult DeleteNewsById(int id)
        {
            _categoriesService.DeleteCategoriesById(id);
            return Ok();
        }

    }
}
