using System;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete.Educator;
using Core.Entities.Concrete.Student;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Core.Utilities.Security.Naming;
using Core.Utilities.Security.Numerator;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IStudentService _studentService;
        IEducatorService _educatorService;
        ITokenHelper _tokenHelper;
        IStudentLessonDal _studentLessonDal;

        public AuthManager(IStudentService studentService, IEducatorService educatorService, ITokenHelper tokenHelper, IStudentLessonDal studentLessonDal)
        {
            _studentService = studentService;
            _educatorService = educatorService;
            _tokenHelper = tokenHelper;
            _studentLessonDal = studentLessonDal;
        }

        public IDataResult<AccessToken> CreateAccessTokenForEducator(Educator educator)
        {
            var claims = _educatorService.GetClaims(educator);
            var accessToken = _tokenHelper.CreateTokenForEducator(educator, claims);

            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<Educator> EducatorLogin(LoginDto loginDto)
        {
            var educatorToCheck = _educatorService.GetByUsername(loginDto.UserName);

            if (educatorToCheck == null)
            {
                return new ErrorDataResult<Educator>(educatorToCheck, Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(loginDto.Password, educatorToCheck.passwordHash, educatorToCheck.passwordSalt))
            {
                return new ErrorDataResult<Educator>(educatorToCheck, Messages.PasswordError);
            }
            return new SuccessDataResult<Educator>(educatorToCheck, Messages.SuccessfullLogin);
        }

        public IDataResult<Educator> EducatorRegister(RegisterDto registerDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(registerDto.Password, out passwordHash, out passwordSalt);

            var educator = new Educator
            {
                email = registerDto.Email,
                firstname = registerDto.FirstName,
                lastname = registerDto.LastName,
                passwordHash = passwordHash,
                passwordSalt = passwordSalt,
                educatorStatus = true,
                title = "Educator",
                deparmentId = registerDto.DepartmentId,
                phoneNumber = registerDto.PhoneNumber,
                educatorNumber = Numerator.CreateEducatorNumber(),
                username = Naming.CreateUserName(registerDto.FirstName, registerDto.LastName)

            };
            _educatorService.Add(educator);

            return new SuccessDataResult<Educator>(educator, Messages.UserRegistered);
        }



        public IResult UserExists(string email)
        {
            if (_educatorService.GetByMail(email) != null || _studentService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }



        public IDataResult<AccessToken> CreateAccessTokenForStudent(Student student)
        {
            var claims = _studentService.GetClaims(student);
            var accessToken = _tokenHelper.CreateTokenForStudent(student, claims);

            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<Student> StudentLogin(LoginDto loginDto)
        {
            var studentToCheck = _studentService.GetByUserName(loginDto.UserName);

            if (studentToCheck == null)
            {
                return new ErrorDataResult<Student>(studentToCheck, Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(loginDto.Password, studentToCheck.passwordHash, studentToCheck.passwordSalt))
            {
                return new ErrorDataResult<Student>(studentToCheck, Messages.PasswordError);
            }
            return new SuccessDataResult<Student>(studentToCheck, Messages.SuccessfullLogin);
        }

        [ValidationAspect(typeof(RegisterValidator), Priority = 1)]
        [TransactionScopeAspect]

        public IDataResult<Student> StudentRegister(RegisterDto registerDto)
        {
            //ValidationTool.Validate(new RegisterValidator(), registerDto);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(registerDto.Password, out passwordHash, out passwordSalt);

            int studentLessonId = Numerator.CreateStudentLessonId();

            var student = new Student
            {
                email = registerDto.Email,
                firstname = registerDto.FirstName,
                lastname = registerDto.LastName,
                passwordHash = passwordHash,
                passwordSalt = passwordSalt,
                studentStatus = true,
                title = "Student",
                deparmentId = registerDto.DepartmentId,
                phoneNumber = registerDto.PhoneNumber,
                studentNumber = Numerator.CreateStudentNumber(),
                username = Naming.CreateUserName(registerDto.FirstName, registerDto.LastName),
                studentLessonId = studentLessonId
            };
            _studentService.Add(student);

            var studentLesson = new StudentLesson
            {
                studentLessonId = studentLessonId,
                studentLessons = ""
            };
            _studentLessonDal.Add(studentLesson);

            return new SuccessDataResult<Student>(student, Messages.UserRegistered);
        }

        public IResult StudentExists(string username)
        {
            if (_studentService.GetByUserName(username) == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult EducatorExists(string username)
        {
            if (_educatorService.GetByUsername(username) == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
