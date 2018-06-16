using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HLSB.Models
{
    public class BinaryObject 
    {
        public virtual int Id { get; set; }

        public virtual string Type { get; set; }

        public virtual byte[] Content { get; set; }

        public virtual string ContentType { get; set; }
    }
}