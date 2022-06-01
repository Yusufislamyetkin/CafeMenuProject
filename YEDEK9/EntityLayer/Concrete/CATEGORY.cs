using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class CATEGORY
    {

        [Key]
        public int CATEGORYID { get; set; }

        public string CATEGORYNAME { get; set; }

        public string PARENTCATEGORYID { get; set; }

        public int CREATORUSERID { get; set; }
        public string CATEGORYIMAGE { get; set; }
      

        public DateTime CREATEDDATE { get; set; }

        public bool ISDELETED { get; set; }


       

       
        public ICollection<PRODUCT> PRODUCTs { get; set; }
    }
}
