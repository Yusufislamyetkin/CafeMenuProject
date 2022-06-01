using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IPROPERTYService
    {

        void AddValue(PROPERTY p);
        PROPERTY GetByID(int id);

        void PROPERTYUpdate(PROPERTY P);
    }
}
