using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HLSB.Models;
using System.IO;
using System.Web.Hosting;
using System.Diagnostics;

namespace HLSB.DAL
{
    public class HlsbInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<HlsbContext>
    {
        public string ServerPath;

        public HlsbInitializer()
        {
            ServerPath = HostingEnvironment.MapPath("~");
            Debug.WriteLine(ServerPath);
        }

        protected override void Seed(HlsbContext context)
        {        
            var users = new List<User>
            {
                new User{ FirstName = "Anakin", LastName = "Skywalker", Surname = "Annie", EmailAddress = "starwars@email.com", IsActive = true, Password = "123"}
            };

            users.ForEach(x => context.Users.Add(x));
            context.SaveChanges();
        }
    }
}