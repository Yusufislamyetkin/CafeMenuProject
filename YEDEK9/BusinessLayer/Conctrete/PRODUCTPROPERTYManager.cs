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
    public class PRODUCTPROPERTYManager : IPRODUCTPROPERTYService
    {
        IPRODUCTPROPERTYDal _PRODUCTPROPERTYDal;

        public PRODUCTPROPERTYManager(IPRODUCTPROPERTYDal pRODUCTPROPERTYDal)
        {
            _PRODUCTPROPERTYDal = pRODUCTPROPERTYDal;
        }

        public void AddValue(PRODUCTPROPERTY PRODUCTPROPERTY)
        {
            _PRODUCTPROPERTYDal.Insert(PRODUCTPROPERTY);
        }

        public PRODUCTPROPERTY GetByID(int id)
        {
           return _PRODUCTPROPERTYDal.Get(x => x.PRODUCTPROPERTYID == id);
        }



    



        public List<PRODUCTPROPERTY> GetListProp(int id)
        {
            return _PRODUCTPROPERTYDal.WhrList(x => x.PRODUCTID == id);
        }

        public PRODUCTPROPERTY GetProp(int id)
        {
            return _PRODUCTPROPERTYDal.Get(x => x.PRODUCTID == id);
        }


        public List<PRODUCTPROPERTY> GetListCategory(int id)
        {
            return _PRODUCTPROPERTYDal.WhrList(x => x.PRODUCT.CATEGORYID == id && x.PRODUCT.ISDELETED == false) ;
        }

 

        public void PRODUCTPROPERTYUpdate(PRODUCTPROPERTY PRODUCTPROPERTY)
        {
            _PRODUCTPROPERTYDal.UpdateNew(PRODUCTPROPERTY, PRODUCTPROPERTY.PRODUCTPROPERTYID);
        }
    }
}
