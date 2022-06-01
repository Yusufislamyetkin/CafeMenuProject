using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class CategoryValidatior: AbstractValidator<CATEGORY>
    {
        public CategoryValidatior()
        {
            RuleFor(x => x.CATEGORYNAME).NotEmpty().WithMessage("Kategori İsmi Boş Bırakılamaz");
          
         
            RuleFor(x => x.CATEGORYNAME).MaximumLength(20).WithMessage("Lütfen En Fazla 20 Karakter Girişi Yapın");
        }
    }
}
