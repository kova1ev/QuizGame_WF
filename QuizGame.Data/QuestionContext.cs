using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuizGame.Domain
{
    public class QuestionContext : DbContext
    {
        private readonly string  devConnection = @"../../../Data.sqlite";
        public DbSet<Question> Questions { get; set; }
        //public QuestionContext() 
        //{
        //    Database.EnsureCreated();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"FileName={devConnection}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
