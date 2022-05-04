using System;
using System.Collections.Generic;

namespace ExamProject.Data.ViewModel
{
    public class NewsVM
    {
        public string Title { get; set; }
        public string Сontent { get; set; }
        public DateTime PublicTime { get; set; }
        public IEnumerable<int> CategoriesId { get; set; }
    }
}
