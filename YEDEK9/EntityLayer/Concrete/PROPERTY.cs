using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
  public  class PROPERTY
    {
        [Key]
        public int PROPERTYID { get; set; }
        public int KEY { get; set; }
        public string VALUE { get; set; }
       


        public ICollection<PRODUCTPROPERTY> PRODUCTPROPERTY { get; set; }
    }
}
