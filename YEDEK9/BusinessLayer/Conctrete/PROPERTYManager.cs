using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Conctrete
{
    public class PROPERTYManager : IPROPERTYService
    {
        IPROPERTYDal _PROPERTYDal;

        public PROPERTYManager(IPROPERTYDal pROPERTYDal)
        {
            _PROPERTYDal = pROPERTYDal;
        }

        public void AddValue(PROPERTY p)
        {
            _PROPERTYDal.Insert(p);
        }

     

        public PROPERTY GetByID(int id)
        {
          return  _PROPERTYDal.Get(x => x.PROPERTYID == id);
        }

     

        public void PROPERTYUpdate(PROPERTY P)
        {
            _PROPERTYDal.UpdateNew(P, P.PROPERTYID);
        }
    }
}
