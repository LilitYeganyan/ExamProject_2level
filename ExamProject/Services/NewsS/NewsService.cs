using ExamProject.Data.Model;
using ExamProject.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ExamProject.Services.NewsS
{
    public class NewsService : INewsService
    {
        private AppDbContext _context { get; set; }
        public NewsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddNews(NewsVM news)
        {
            var _news = new News()
            {
                Title = news.Title,
                Сontent = news.Сontent,
                PublicTime = DateTime.Now
            };

            foreach (var id in news.CategoriesId)
            {
                var news_Vategories = new News_Category()
                {
                    NewsId = _news.Id,
                    CategoryId = id
                };
            }
            await _context.news.AddAsync(_news);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<News>> GetAllNews()
        {
            var _newsList = _context.news;
            return await Task.FromResult(_newsList);
        }

        public async Task<News> UpdateNewsById(int id, NewsVM news)
        {
            var _news = _context.news.FirstOrDefault(n => n.Id == id);
            if (_news != null)
            {
                _news.Title = news.Title;
                _news.Сontent = news.Сontent;
                _news.PublicTime = DateTime.Now;

                _context.SaveChanges();
            }

            return await Task.FromResult(_news);
        }

        public void DeleteNewsById(int id)
        {
            var _news = _context.news.FirstOrDefault(n => n.Id == id);
            if (_news != null)
            {
                _context.news.Remove(_news);
                _context.SaveChanges();
            }
        }

     
    }
}
