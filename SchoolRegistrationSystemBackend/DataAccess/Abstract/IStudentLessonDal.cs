using System;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract
{
    public interface IStudentLessonDal : IEntityRepository<StudentLesson>
    {
        void AddStudentLesson(LessonDto lessonDto);

        void DeleteStudentLesson(LessonDto lessonDto);
    }
}
