using ExamProject.Data.Model;
using ExamProject.Data.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamProject.Services.NewsS
{
    public interface INewsService
    {
        Task AddNews(NewsVM news);
        Task<IEnumerable<News>> GetAllNews();
        Task<News> UpdateNewsById(int id, NewsVM news);
        void DeleteNewsById(int id);
    }
}
