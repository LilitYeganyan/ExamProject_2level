using ExamProject.Data.Model;
using ExamProject.Data.ViewModel;
using ExamProject.Services.NewsS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ExamProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private INewsService _newsService { get; set; }
        private ILogger<NewsController> _logger { get; set; }
        public NewsController(INewsService service, ILogger<NewsController> logger)
        {
            _newsService = service;
            _logger = logger;
        }

        [HttpPost("add-News")]
        public async Task<IActionResult> AddNews([FromBody] NewsVM news)
        {
            try
            {
                await _newsService.AddNews(news);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-news")]
        public async Task<IActionResult> GetAllNews()
        {
            try
            {
                var newsList = _newsService.GetAllNews();
                return Ok(await newsList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-news-by-id/{id}")]
        public async Task<IActionResult> UpdateNewsById(int id, [FromBody] NewsVM news)
        {
            try
            {
                var _news = _newsService.UpdateNewsById(id, news);
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
            _newsService.DeleteNewsById(id);
            return Ok();
        }

        [Route(@"daterange/{startDateString}/{endDateString}")]
        [HttpGet]
        public async Task<IActionResult> GetNewsinGivenRang()
        {

        }

    }
}
