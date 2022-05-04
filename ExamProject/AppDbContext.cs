using ExamProject.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ExamProject
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBulider)
        {
            modelBulider.Entity<News_Category>().
                HasOne(ne => ne.News).
                WithMany(n => n.News_Categories).
                HasForeignKey(ni => ni.NewsId);

            modelBulider.Entity<News_Category>().
                HasOne(co => co.Category).
                WithMany(c => c.News_Categories).
                HasForeignKey(ci => ci.CategoryId);
        }
        public DbSet<News> news { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<News_Category> news_categories { get; set; }
    }
}
