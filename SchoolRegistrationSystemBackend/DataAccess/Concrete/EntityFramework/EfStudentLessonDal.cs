using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfStudentLessonDal : EfEntityRepositoryBase<StudentLesson, Context>, IStudentLessonDal
    {
        public void AddStudentLesson(LessonDto lessonDto)
        {
            using (var context = new Context())
            {
                var chosenLesson = context.Lesson.AsNoTracking().SingleOrDefault(l => l.lessonId == lessonDto.LessonId);

                var currentStudentLesson = context.StudentLessons.AsNoTracking().SingleOrDefault(s => s.studentId == lessonDto.StudentId);

                if (chosenLesson.lessonCapacity == 0)
                {
                    throw new Exception("The Lesson Capacity is Full");
                }

                if (currentStudentLesson.studentLessons.Contains(chosenLesson.lessonName))
                {
                    throw new Exception("Can Not Choose The Same Lesson");
                }

                var studentLessons = new StudentLesson
                {
                    studentLessonId = currentStudentLesson.studentLessonId,

                    studentId = currentStudentLesson.studentId,

                    studentLessons = (currentStudentLesson.studentLessons == "")
                    ? chosenLesson.lessonName
                    : currentStudentLesson.studentLessons + "," + chosenLesson.lessonName
                };

                var entity = context.Entry(studentLessons);

                entity.State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void DeleteStudentLesson(LessonDto lessonDto)
        {
            using (var context = new Context())
            {
                var chosenLesson = context.Lesson.AsNoTracking().SingleOrDefault(l => l.lessonId == lessonDto.LessonId);

                var currentStudentLesson = context.StudentLessons.AsNoTracking().SingleOrDefault(s => s.studentId == lessonDto.StudentId);

                string updatedLesson = currentStudentLesson.studentLessons.Replace("," + chosenLesson.lessonName, string.Empty)
                    .Replace(chosenLesson.lessonName, null);

                var studentLessons = new StudentLesson
                {
                    studentLessonId = currentStudentLesson.studentLessonId,

                    studentId = currentStudentLesson.studentId,

                    studentLessons = updatedLesson
                };

                var entity = context.Entry(studentLessons);

                entity.State = EntityState.Modified;

                context.SaveChanges();
            }
        }
    }
}
