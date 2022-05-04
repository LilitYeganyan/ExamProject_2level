using System;
using System.Collections.Generic;

namespace ExamProject.Data.Model
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Сontent { get; set; }
        public DateTime PublicTime { get; set; }

        //Navigation Properties 
        public IEnumerable<News_Category> News_Categories { get; set; }

    }
}
