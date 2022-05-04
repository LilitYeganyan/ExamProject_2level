using ExamProject.Data.Model;
using ExamProject.Data.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamProject.Services.CategoryS
{
    public class CategoriesService: ICategoriesService
    {
        private AppDbContext _context;
        public CategoriesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCategory(CategoryVM category)
        {
            var _category = new Category()
            {
                Name = category.Name
            };
            await _context.categories.AddAsync(_category);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories = _context.categories;
            return await Task.FromResult(categories);
        }

        public async Task<Category> UpdateNewsById(int id, CategoryVM category)
        {
            var _ctegory = _context.categories.FirstOrDefault(c=>c.Id == id);
            if (_ctegory != null)
            {
                _ctegory.Name = category.Name;

                _context.SaveChanges();
            }

            return await Task.FromResult(_ctegory);
        }

        public void DeleteCategoriesById(int id)
        {
            var _category = _context.categories.FirstOrDefault(n => n.Id == id);
            if (_category != null)
            {
                _context.categories.Remove(_category);
                _context.SaveChanges();
            }
        }
    }
}
