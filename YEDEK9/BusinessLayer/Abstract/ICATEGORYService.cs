using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface ICATEGORYService
    {
        void AddValue(CATEGORY CATEGORY);
        List<CATEGORY> GetList();
        CATEGORY GetByID(int id);
        List<CATEGORY> GetByUserID(int? id);
        void CategoryDelete(CATEGORY CATEGORY);
        void CategoryUpdate(CATEGORY CATEGORY, int id);
    }
}
