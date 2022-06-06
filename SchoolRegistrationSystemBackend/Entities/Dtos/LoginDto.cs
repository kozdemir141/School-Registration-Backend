using System;
using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class LoginDto:IDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
