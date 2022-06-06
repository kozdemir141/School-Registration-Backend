using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Entities.Concrete.Educator;
using Core.Entities.Concrete.Student;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateTokenForStudent(Student student, List<OperationClaim> operationClaims);

        AccessToken CreateTokenForEducator(Educator educator, List<OperationClaim> operationClaims);
    }
}
