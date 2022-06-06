using System;
using System.Collections.Generic;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class StudentLesson : IEntity
    {
        public int studentId { get; set; }

        public int studentLessonId { get; set; }

        public string studentLessons { get; set; }
    }
}
