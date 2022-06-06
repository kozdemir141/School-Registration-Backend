using System;
using Core.Entities.Abstract;

namespace Core.Entities.Concrete.Student
{
    public class Student : IEntity
    {
        public int studentId { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string username { get; set; }

        public int studentNumber { get; set; }

        public string email { get; set; }

        public int deparmentId { get; set; }

        public string deparment { get; set; }

        public bool studentStatus { get; set; }

        public byte[] passwordSalt { get; set; }

        public byte[] passwordHash { get; set; }

        public string title { get; set; }

        public string phoneNumber { get; set; }

        public int studentLessonId { get; set; }
    }
}
