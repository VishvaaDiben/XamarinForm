using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HLSB.DAL;
using HLSB.Models;
using HLSB.Models.Dto;
using System.Reflection;

namespace HLSB.Controllers
{
    public class UsersViewController : Controller
    {
        private HlsbContext db = new HlsbContext();

        // GET: UsersView
        public async Task<ActionResult> Index()
        {
            var users = (await db.Users
                .ToListAsync())
                .Select(x => new User
                {
                    UserId = x.UserId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Surname = x.Surname,
                    EmailAddress = x.EmailAddress,
                    IsActive = x.IsActive,
                    ProfilePictureString = x.ProfilePictureString,
                    Password = HashPassword(x.Password)
                })
                .ToList();

            return View(users);
        }

        // GET: UsersView/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (user == null)
            {
                return HttpNotFound();
            }

            UserDto dto = new UserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Surname = user.Surname,
                EmailAddress = user.EmailAddress,
                Password = HashPassword(user.Password),
                IsActive = user.IsActive,
                ProfilePicture = user.ProfilePictureString
            };

            return View(dto);
        }

        // GET: UsersView/Create
        public ActionResult Create()
        {
            User user = new User();
            UserDto dto = new UserDto
            {
                UserId = null,
                IsActive = true,
                ProfilePicture = user.ProfilePictureString
            };

            return View(dto);
        }

        // POST: UsersView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserId,FirstName,LastName,Surname,EmailAddress,Password,IsActive,ProfilePicture")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: UsersView/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (user == null)
            {
                return HttpNotFound();
            }

            user.Password = HashPassword(user.Password);

            return View(user);
        }

        // POST: UsersView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserId,FirstName,LastName,Surname,EmailAddress,Password,IsActive,ProfilePicture")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Details", user.UserId);
        }

        // GET: UsersView/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (user == null)
            {
                return HttpNotFound();
            }

            user.Password = HashPassword(user.Password);

            return View(user);
        }

        // POST: UsersView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.UserId == id);
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public static string ByteToBase64(byte[] data)
        {
            return Convert.ToBase64String(data);
        }

        private static string HashPassword(string password)
        {
            string hashedPassword = string.Empty;

            foreach (var p in password)
                hashedPassword += "*";

            return hashedPassword;
        }
        
    }
}
