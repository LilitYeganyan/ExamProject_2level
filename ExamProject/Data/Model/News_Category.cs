namespace ExamProject.Data.Model
{
    public class News_Category
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
