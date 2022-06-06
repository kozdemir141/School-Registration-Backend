using System;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLessonDal : EfEntityRepositoryBase<Lesson, Context>, ILessonDal
    {
        public void DecreaseLessonCapacity(int lessonId)
        {
            using (var context = new Context())
            {
                var currentLesson = context.Lesson.AsNoTracking().SingleOrDefault(l => l.lessonId == lessonId);

                var updatedLesson = new Lesson
                {
                    lessonId = currentLesson.lessonId,
                    lessonName = currentLesson.lessonName,
                    lessonCapacity = (currentLesson.lessonCapacity - 1)
                };

                var entity = context.Entry(updatedLesson);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void IncreaseLessonCapacity(int lessonId)
        {
            using (var context = new Context())
            {
                var currentLesson = context.Lesson.AsNoTracking().SingleOrDefault(l => l.lessonId == lessonId);

                var updatedLesson = new Lesson
                {
                    lessonId = currentLesson.lessonId,
                    lessonName = currentLesson.lessonName,
                    lessonCapacity = (currentLesson.lessonCapacity + 1)
                };

                var entity = context.Entry(updatedLesson);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public override void Update(Lesson lesson)
        {
            using (var context = new Context())
            {
                var currentLesson = context.Lesson.AsNoTracking().SingleOrDefault(l => l.lessonId == lesson.lessonId);

                var updatedLesson = new Lesson
                {
                    lessonId = currentLesson.lessonId,
                    lessonName = (lesson.lessonName == null) ? currentLesson.lessonName : lesson.lessonName,
                    lessonCapacity = (lesson.lessonCapacity == 0) ? currentLesson.lessonCapacity : lesson.lessonCapacity
                };

                var entity = context.Entry(updatedLesson);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
