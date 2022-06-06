using System;
using Core.Entities.Concrete.Educator;
using Core.Entities.Concrete.Student;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IAuthService
    {
        //STUDENT

        IDataResult<Student> StudentRegister(RegisterDto registerDto);

        IDataResult<Student> StudentLogin(LoginDto loginDto);

        IResult UserExists(string email);

        IDataResult<AccessToken> CreateAccessTokenForStudent(Student student);

        IResult StudentExists(string username);

        //EDUCATOR

        IResult EducatorExists(string username);

        IDataResult<Educator> EducatorRegister(RegisterDto registerDto);

        IDataResult<Educator> EducatorLogin(LoginDto loginDto);

        IDataResult<AccessToken> CreateAccessTokenForEducator(Educator educator);

    }
}
