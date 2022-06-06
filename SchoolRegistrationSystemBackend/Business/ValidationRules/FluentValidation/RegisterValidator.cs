using System;
using Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(r => r.FirstName).NotNull();
            RuleFor(r => r.FirstName).Length(3, 20);
            RuleFor(r => r.FirstName).Must(StartWithUpperCase);

            RuleFor(r => r.LastName).NotNull();
            RuleFor(r => r.LastName).Length(3, 20);
            RuleFor(r => r.LastName).Must(StartWithUpperCase);

            RuleFor(r => r.Email).NotNull();
            RuleFor(r => r.Email).EmailAddress();

            RuleFor(r => r.Password).NotNull();
            RuleFor(r => r.Password).MinimumLength(8);

            RuleFor(r => r.DepartmentId).NotNull();
        }

        private bool StartWithUpperCase(string arg)
        {
            return arg.StartsWith(char.ToUpper(arg[0]));
        }
    }
}
