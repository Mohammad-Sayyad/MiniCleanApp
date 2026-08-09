using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzmoonGaj.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("شناسه کاربر معتبر نیست.");

            RuleFor(x => x.UserDto)
                .NotNull().WithMessage("اطلاعات کاربر جهت بروزرسانی ارسال نشده است.");

            RuleFor(x => x.UserDto.Name)
                .NotEmpty().WithMessage("نام الزامی است.")
                .When(x => x.UserDto != null);

            RuleFor(x => x.UserDto.LastName)
                .NotEmpty().WithMessage("نام خانوادگی الزامی است.")
                .When(x => x.UserDto != null);
        }
    }
}
