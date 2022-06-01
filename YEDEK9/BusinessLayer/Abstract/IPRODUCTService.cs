using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IPRODUCTService
    {
        void AddValue(PRODUCT p);
        PRODUCT GetByID(int id);
        PRODUCT GetByIDProduct(int id);
        List<PRODUCT> GetByContent(int id);
     
        void PRODUCTUpdate(PRODUCT PRODUCT);
        List<PRODUCT> GetList();
    }
}
