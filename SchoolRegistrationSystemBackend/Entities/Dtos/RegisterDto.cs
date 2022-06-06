using System;
using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class RegisterDto:IDto
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int DepartmentId { get; set; }  

        public string PhoneNumber { get; set; }
    }
}
