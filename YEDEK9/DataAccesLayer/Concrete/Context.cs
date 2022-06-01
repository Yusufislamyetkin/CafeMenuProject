using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete
{
   public  class Context : DbContext
    {


        public DbSet<User> USER { get; set; }


        public DbSet<PRODUCT> PRODUCT { get; set; }
        public DbSet<CATEGORY> CATEGORies { get; set; }
        public DbSet<PRODUCTPROPERTY> PRODUCTPROPERTies { get; set; }
        public DbSet<PROPERTY> PROPERTies { get; set; }

    }
}
