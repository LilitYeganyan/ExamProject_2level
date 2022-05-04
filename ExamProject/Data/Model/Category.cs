using System.Collections.Generic;

namespace ExamProject.Data.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Propeties
        public IEnumerable<News_Category> News_Categories { get; set; }


    }
}
