using System;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IStudentLessonService
    {
        IResult AddStudentLesson(LessonDto lessonDto);

        IResult DeleteStudentLesson(LessonDto lessonDto);

        IDataResult<StudentLesson> GetStudentLessons(int studentId);
    }
}
