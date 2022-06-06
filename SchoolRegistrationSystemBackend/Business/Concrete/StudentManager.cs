using System;
using System.Collections.Generic;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Concrete.Student;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class StudentManager:IStudentService
    {
        IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public void Add(Student student)
        {
            _studentDal.Add(student);
        }

        public void Delete(Student student)
        {
            _studentDal.Delete(student);
        }

        public Student GetByMail(string email)
        {
            return _studentDal.Get(s => s.email == email);
        }

        public Student GetByUserName(string username)
        {
            return _studentDal.Get(s => s.username == username);
        }

        public List<OperationClaim> GetClaims(Student student)
        {
            return _studentDal.GetClaims(student);
        }

        public void Update(Student student)
        {
            _studentDal.Update(student);
        }
    }
}
