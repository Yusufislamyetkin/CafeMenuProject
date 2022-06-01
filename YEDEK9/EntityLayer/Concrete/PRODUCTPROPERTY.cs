using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class PRODUCTPROPERTY
    {
        [Key]
        public int PRODUCTPROPERTYID { get; set; }


        public int PROPERTYID { get; set; }
        public virtual PROPERTY PROPERTY { get; set; }

        public int PRODUCTID { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
    }
}
