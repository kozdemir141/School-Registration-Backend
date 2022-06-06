using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Entities.Concrete.Student;

namespace Business.Abstract
{
    public interface IStudentService
    {
        List<OperationClaim> GetClaims(Student student);

        Student GetByMail(string email);

        Student GetByUserName(string username);

        void Add(Student student);

        void Delete(Student student);

        void Update(Student student);
    }
}
