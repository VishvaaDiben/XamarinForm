using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HLSB.Models.Dto
{
    public class SessionDto
    {
        public long? UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}