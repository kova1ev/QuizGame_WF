using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuizGame.Data
{
    public class QuestionContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public QuestionContext() 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName=Data.sqlite");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
