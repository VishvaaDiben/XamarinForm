namespace HLSB.Migrations
{
    using HLSB.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Web.Hosting;

    internal sealed class Configuration : DbMigrationsConfiguration<HLSB.DAL.HlsbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HLSB.DAL.HlsbContext";
        }

        protected override void Seed(HLSB.DAL.HlsbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var images = new List<BinaryObject>
            {
                new BinaryObject{ Content = File.ReadAllBytes("C:/Users/kuganesan.kumar/source/repos/HLSB/HLSB/Images/cannon.jpg"), ContentType = "image/jpg", Type = "Product" },
                new BinaryObject{ Content = File.ReadAllBytes("C:/Users/kuganesan.kumar/source/repos/HLSB/HLSB/Images/epson.jpg"), ContentType = "image/jpg", Type = "Product" },
                new BinaryObject{ Content = File.ReadAllBytes("C:/Users/kuganesan.kumar/source/repos/HLSB/HLSB/Images/lexmark.jpg"), ContentType = "image/jpg", Type = "Product" }

            };

            images.ForEach(x => context.BinaryObjects.Add(x));
            context.SaveChanges();

            var users = new List<User>
            {
                new User{ FirstName = "Anakin", LastName = "Skywalker", Surname = "Annie", EmailAddress = "starwars@email.com", IsActive = true, Password = "123", ProfilePicture = File.ReadAllBytes("C:/Users/kuganesan.kumar/source/repos/HLSB/HLSB/Images/default-profile.png")}
            };

            users.ForEach(x => context.Users.Add(x));
            context.SaveChanges();

        }
    }
}
