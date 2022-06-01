using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class UserRegisterValidator:AbstractValidator<User>
    {
        public UserRegisterValidator()
        {
            RuleFor(x => x.NAME).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
            RuleFor(x => x.SURNAME).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");

            RuleFor(x => x.SALTPASSWORD).MaximumLength(100).WithMessage("Maximum 10 karakter kullanın");
        



        }
    }
}
