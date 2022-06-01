using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class PRODUCT
    {

        [Key]
        public int PRODUCTID { get; set; }

        public string PRODUCNAME { get; set; }

        public string IMAGEPATH { get; set; }

        public int PRICE { get; set; }

        public bool ISDELETED { get; set; }

        public DateTime CREATEDDATE { get; set; }

        public int CREATORUSERID { get; set; }

        public int CATEGORYID { get; set; }
        public virtual CATEGORY CATEGORY { get; set; }


        public ICollection<PRODUCTPROPERTY> PRODUCTPROPERTies { get; set; }


    }
}
