using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IPRODUCTPROPERTYService
    {

        void AddValue(PRODUCTPROPERTY PRODUCTPROPERTY);
        PRODUCTPROPERTY GetProp(int id);
       
        List<PRODUCTPROPERTY> GetListProp(int id);
        List<PRODUCTPROPERTY> GetListCategory(int id);
        PRODUCTPROPERTY GetByID(int id);
  
        void PRODUCTPROPERTYUpdate(PRODUCTPROPERTY PRODUCTPROPERTY);
    }
}
