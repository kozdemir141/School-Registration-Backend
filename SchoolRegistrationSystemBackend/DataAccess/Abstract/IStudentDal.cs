using System;
using System.Collections.Generic;
using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Entities.Concrete.Student;

namespace DataAccess.Abstract
{
    public interface IStudentDal:IEntityRepository<Student>
    {
        List<OperationClaim> GetClaims(Student student);
    }
}
