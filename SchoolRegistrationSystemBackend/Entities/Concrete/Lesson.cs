using System;
using System.Collections.Generic;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Lesson : IEntity
    {
        public int lessonId { get; set; }

        public string lessonName { get; set; }

        public int lessonCapacity { get; set; }
    }
}
