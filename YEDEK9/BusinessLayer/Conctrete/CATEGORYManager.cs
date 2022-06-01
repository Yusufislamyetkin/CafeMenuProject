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
    public class CATEGORYManager : ICATEGORYService
    {
        ICATEGORYDal _CategoryDal;

        public CATEGORYManager(ICATEGORYDal CategoryDal)
        {
            _CategoryDal = CategoryDal;
        }

        public void AddValue(CATEGORY CATEGORY)
        {
            _CategoryDal.Insert(CATEGORY);
        }

        public void CategoryDelete(CATEGORY CATEGORY)
        {
            _CategoryDal.Delete(CATEGORY);
        }

        public void CategoryUpdate(CATEGORY CATEGORY,int id)
        {
            _CategoryDal.UpdateNew(CATEGORY,CATEGORY.CATEGORYID);
        }

        public CATEGORY GetByID(int id)
        {
          return  _CategoryDal.Get(x => x.CATEGORYID == id);
        }

        public List<CATEGORY> GetByUserID(int? id)
        {
            throw new NotImplementedException();
        }

        public List<CATEGORY> GetList()
        {
            return _CategoryDal.WhrList(x => x.ISDELETED == false);
        }
    }
}
