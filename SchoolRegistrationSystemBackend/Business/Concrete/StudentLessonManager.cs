using System;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class StudentLessonManager : IStudentLessonService
    {
        IStudentLessonDal _studentLessonDal;
        ILessonDal _lessonDal;

        public StudentLessonManager(IStudentLessonDal studentLessonDal, ILessonDal lessonDal)
        {
            _studentLessonDal = studentLessonDal;
            _lessonDal = lessonDal;
        }

        [TransactionScopeAspect]

        public IResult AddStudentLesson(LessonDto lessonDto)
        {
            _studentLessonDal.AddStudentLesson(lessonDto);

            try
            {
                _lessonDal.DecreaseLessonCapacity(lessonDto.LessonId);
                return new SuccessResult(Messages.LessonAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }

        }

        [TransactionScopeAspect]

        public IResult DeleteStudentLesson(LessonDto lessonDto)
        {
            _studentLessonDal.DeleteStudentLesson(lessonDto);
            _lessonDal.IncreaseLessonCapacity(lessonDto.LessonId);
            return new SuccessResult(Messages.LessonDeleted);
        }

        public IDataResult<StudentLesson> GetStudentLessons(int studentId)
        {
            return new SuccessDataResult<StudentLesson>(_studentLessonDal.Get(s => s.studentId == studentId));
        }
    }
}
