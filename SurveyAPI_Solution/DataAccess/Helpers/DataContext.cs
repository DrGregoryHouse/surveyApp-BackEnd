using Domain.Entities;
using System.Data.Entity;

namespace DataAccess.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; }

        public DbSet<Option> Options { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<QuestionType> QuestionTypes { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Survey> Surveys { get; set; }

        public DataContext() : base("SurveyDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>()
                .Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(100);

            modelBuilder.Entity<Survey>()
                .Property(x => x.Description)
                    .IsRequired()
                    .HasMaxLength(500);

            modelBuilder.Entity<Question>()
                .Property(x => x.Text)
                    .IsRequired()
                    .HasMaxLength(150);

            modelBuilder.Entity<QuestionType>()
                .Property(x => x.Description)
                    .IsRequired()
                    .HasMaxLength(50);

            modelBuilder.Entity<Option>()
                .Property(x => x.Text)
                    .IsRequired()
                    .HasMaxLength(50);

            modelBuilder.Entity<Option>()
                .Property(x => x.Value)
                    .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
