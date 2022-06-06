using System;
using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Entities.Concrete.Student;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfStudentDal : EfEntityRepositoryBase<Student, Context>, IStudentDal
    {
        public List<OperationClaim> GetClaims(Student student)
        {
            using (var context = new Context())
            {
                var result = from operationClaim in context.OperationClaims
                             join studentOperationClaim in context.StudentOperationClaims

                             on operationClaim.id equals studentOperationClaim.operationClaimId
                             //where studentOperationClaim.studentId == student.studentId
                             select new OperationClaim { id = operationClaim.id, name = operationClaim.name };

                return result.ToList();
            }
        }
        public override void Add(Student student)
        {
            using (var context = new Context())
            {
                var currentDepartment = context.Deparment.AsNoTracking().SingleOrDefault(d => d.deparmentId == student.deparmentId);

                var addedStudent = new Student
                {
                    email = student.email,
                    firstname = student.firstname,
                    lastname = student.lastname,
                    passwordHash = student.passwordHash,
                    passwordSalt = student.passwordSalt,
                    studentStatus = true,
                    title = "Student",
                    deparmentId = student.deparmentId,
                    deparment = currentDepartment.deparmentName,
                    phoneNumber = student.phoneNumber,
                    studentNumber = student.studentNumber,
                    username = student.username,
                    studentLessonId = student.studentLessonId
                };

                var entity = context.Entry(addedStudent);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
