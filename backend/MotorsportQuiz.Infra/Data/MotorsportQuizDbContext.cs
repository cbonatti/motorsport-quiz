using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MotorsportQuiz.Domain;

namespace MotorsportQuiz.Infra.Data
{
    public class MotorsportQuizDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlite(DatabaseConnection.ConnectionConfiguration
                                                    .GetConnectionString("DefaultConnection"));
            }

            dbContextOptionsBuilder.UseLazyLoadingProxies();
        }

        public MotorsportQuizDbContext(DbContextOptions<MotorsportQuizDbContext> option) : base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
    }
}
