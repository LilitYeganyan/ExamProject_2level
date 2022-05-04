using ExamProject.Data.Model;
using ExamProject.Data.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamProject.Services.CategoryS
{
    public interface ICategoriesService
    {
        Task AddCategory(CategoryVM category);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> UpdateNewsById(int id, CategoryVM category);
        void DeleteCategoriesById(int id);

    }
}
