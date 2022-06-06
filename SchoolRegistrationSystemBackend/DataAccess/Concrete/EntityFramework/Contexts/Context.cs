using System;
using Core.Entities.Concrete;
using Core.Entities.Concrete.Educator;
using Core.Entities.Concrete.Student;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"Server=localhost;database=context;user=root;password=55431921");
        }
        //Student

        public DbSet<Student> Student { get; set; }

        public DbSet<StudentOperationClaim> StudentOperationClaims { get; set; }

        //Educator

        public DbSet<Educator> Educator { get; set; }

        public DbSet<EducatorOperationClaim> EducatorOperationClaims { get; set; }

        //Claim
        public DbSet<OperationClaim> OperationClaims { get; set; }

        //Lesson

        public DbSet<Lesson> Lesson { get; set; }

        //StudentLesson

        public DbSet<StudentLesson> StudentLessons { get; set; }

        //Deparment

        public DbSet<Deparment> Deparment { get; set; }
    }
}
