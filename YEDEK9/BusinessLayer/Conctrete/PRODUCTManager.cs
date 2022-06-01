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
    public class PRODUCTManager : IPRODUCTService
    {
        IPRODUCTDal _PRODUCTDal;

        public PRODUCTManager(IPRODUCTDal PRODUCTDal)
        {
            _PRODUCTDal = PRODUCTDal;
        }

        public void AddValue(PRODUCT p)
        {
            _PRODUCTDal.Insert(p);
        }

        public PRODUCT GetByIDProduct(int id)
        {
            return _PRODUCTDal.Get(x => x.PRODUCTID == id);
        }

        public PRODUCT GetByID(int id)
        {
           return _PRODUCTDal.Get(x => x.CATEGORYID == id);
        }

        public List<PRODUCT> GetByContent(int id)
        {
          return  _PRODUCTDal.WhrList(x => x.CATEGORYID == id && x.ISDELETED == false);

        }


        public List<PRODUCT> GetList()
        {
            return _PRODUCTDal.List();

        }

   

        public void PRODUCTUpdate(PRODUCT PRODUCT)
        {
            _PRODUCTDal.UpdateNew(PRODUCT, PRODUCT.PRODUCTID);
        }
    }
}
