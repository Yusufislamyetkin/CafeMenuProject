using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PropertyValidator : AbstractValidator<PROPERTY>
    {
        public PropertyValidator()
        
        
        
        {
            RuleFor(x => x.VALUE).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
            RuleFor(x => x.VALUE).MaximumLength(30).WithMessage("Maximum 30 karakter kullanın");
            






        }
 
    }
}
