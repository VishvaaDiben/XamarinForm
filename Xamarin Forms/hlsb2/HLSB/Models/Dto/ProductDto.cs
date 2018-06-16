using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HLSB.Models.Dto
{
    public class ProductDto
    {
        public long? ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDetail { get; set; }

        public double ProductPrice { get; set; }

        public string ProductImage { get; set; }
        
    }
}