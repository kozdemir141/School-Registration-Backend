using System;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ILessonDal:IEntityRepository<Lesson>
    {
        void DecreaseLessonCapacity(int lessonId);

        void IncreaseLessonCapacity(int lessonId);
    }
}
