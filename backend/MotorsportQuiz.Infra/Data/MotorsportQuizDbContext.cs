using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MotorsportQuiz.Domain;
using System;
using System.Collections.Generic;

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
            var inglaterraID = Guid.Parse("e987dd39-b377-4df0-9b4f-d70538121d70");
            var usaID = Guid.Parse("fe5e1bbc-edd7-4153-81a2-add6908b0b1f");
            var alemanhaID = Guid.Parse("4ef0f07c-2450-454f-8364-f6703621fb3b");
            var japaoID = Guid.Parse("74d4504d-f55b-49a6-b35e-19b90abb8904");

            var bmwID = Guid.Parse("46800301-9e10-44ce-80ee-c5097e69080a");
            var toyotaID = Guid.Parse("3eb99380-568e-449d-842c-d997a56875c0");
            var miniID = Guid.Parse("473d113f-0279-422a-afb3-6533908df4b9");
            var gmID = Guid.Parse("a6c4affe-770d-4258-8906-eb5707756c94");
            var rollsRoyceID = Guid.Parse("296b4c6f-9dff-492b-90f2-4bcb7d7344cb");

            modelBuilder.Entity<Answer>().HasData(new Answer(inglaterraID, "Inglaterra"));
            modelBuilder.Entity<Answer>().HasData(new Answer(usaID, "USA"));
            modelBuilder.Entity<Answer>().HasData(new Answer(alemanhaID, "Alemanha"));
            modelBuilder.Entity<Answer>().HasData(new Answer(japaoID, "Japão"));

            modelBuilder.Entity<Question>().HasData(new Question(bmwID, "BMW"));
            modelBuilder.Entity<Question>().HasData(new Question(toyotaID, "Toyota"));
            modelBuilder.Entity<Question>().HasData(new Question(miniID, "Mini"));
            modelBuilder.Entity<Question>().HasData(new Question(gmID, "General Motors"));
            modelBuilder.Entity<Question>().HasData(new Question(rollsRoyceID, "Rolls-Royce"));

            modelBuilder.Entity<QuestionAnswer>().HasData(new QuestionAnswer(bmwID, inglaterraID, false));
            modelBuilder.Entity<QuestionAnswer>().HasData(new QuestionAnswer(bmwID, usaID, false));
            modelBuilder.Entity<QuestionAnswer>().HasData(new QuestionAnswer(bmwID, alemanhaID, true));
            modelBuilder.Entity<QuestionAnswer>().HasData(new QuestionAnswer(bmwID, japaoID, false));

            modelBuilder.Entity<QuestionAnswer>().HasData(new QuestionAnswer(toyotaID, inglaterraID, false));
            modelBuilder.Entity<QuestionAnswer>().HasData(new QuestionAnswer(toyotaID, usaID, false));
            modelBuilder.Entity<QuestionAnswer>().HasData(new QuestionAnswer(toyotaID, alemanhaID, false));
            modelBuilder.Entity<QuestionAnswer>().HasData(new QuestionAnswer(toyotaID, japaoID, true));

            modelBuilder.Entity<QuestionAnswer>().HasData(new QuestionAnswer(miniID, inglaterraID, true));
            modelBuilder.Entity<QuestionAnswer>().HasData(new QuestionAnswer(miniID, usaID, false));
            modelBuilder.Entity<QuestionAnswer>().HasData(new QuestionAnswer(miniID, alemanhaID, false));
            modelBuilder.Entity<QuestionAnswer>().HasData(new QuestionAnswer(miniID, japaoID, false));

            modelBuilder.Entity<QuestionAnswer>().HasData(new QuestionAnswer(gmID, inglaterraID, false));
            modelBuilder.Entity<QuestionAnswer>().HasData(new QuestionAnswer(gmID, usaID, true));
            modelBuilder.Entity<QuestionAnswer>().HasData(new QuestionAnswer(gmID, alemanhaID, false));
            modelBuilder.Entity<QuestionAnswer>().HasData(new QuestionAnswer(gmID, japaoID, false));

            modelBuilder.Entity<QuestionAnswer>().HasData(new QuestionAnswer(rollsRoyceID, inglaterraID, true));
            modelBuilder.Entity<QuestionAnswer>().HasData(new QuestionAnswer(rollsRoyceID, usaID, false));
            modelBuilder.Entity<QuestionAnswer>().HasData(new QuestionAnswer(rollsRoyceID, alemanhaID, false));
            modelBuilder.Entity<QuestionAnswer>().HasData(new QuestionAnswer(rollsRoyceID, japaoID, false));
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
    }
}
