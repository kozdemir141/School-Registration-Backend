using System;
using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class LessonDto:IDto
    {
        public int StudentId { get; set; }

        public int LessonId { get; set; }
    }
}
