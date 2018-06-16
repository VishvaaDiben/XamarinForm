using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HLSB.Models.Dto
{
    public class UserDto
    {
        public long? UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public string ProfilePicture { get; set; }
    }
}