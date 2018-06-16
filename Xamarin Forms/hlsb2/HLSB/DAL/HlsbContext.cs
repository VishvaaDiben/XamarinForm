using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HLSB.Models;

namespace HLSB.DAL
{
    public class HlsbContext : DbContext
    {
        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<BinaryObject> BinaryObjects { get; set; }
        public virtual IDbSet<Product> Products { get; set; }

        public HlsbContext() : base("HlsbContext")
        {

        }
    }
}