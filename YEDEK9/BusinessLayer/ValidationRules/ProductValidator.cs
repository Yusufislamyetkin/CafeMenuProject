using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ProductValidator:AbstractValidator<PRODUCT>
    {
        public ProductValidator()
        {
            RuleFor(x => x.PRICE).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
            RuleFor(x => x.PRODUCNAME).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");

            RuleFor(x => x.PRICE).GreaterThan(0).WithMessage("Fiyat 0 ' dan büyük olmalı");

        }
    }
}
