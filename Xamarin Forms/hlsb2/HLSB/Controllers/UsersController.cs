using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HLSB.DAL;
using HLSB.Models;
using HLSB.Models.Dto;
using System.Text;
using System.Dynamic;

namespace HLSB.Controllers
{
    public class UsersController : ApiController
    {
        private HlsbContext db = new HlsbContext();

       
        // GET: api/Users/5
        //public async Task<UserDto> GetUser(long id)
        //{
        //    User user = await db.Users
        //        .FirstOrDefaultAsync(x => x.UserId == id);

        //    if (user == null)
        //        return null;

        //    UserDto dto = new UserDto
        //    {
        //        UserId = user.UserId,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        EmailAddress = user.EmailAddress,
        //        Surname = user.Surname,
        //        ProfilePicture = Convert.ToBase64String(user.ProfilePicture)
                
        //    };

        //    return dto;
        //}

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(long id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent); //NoContent(204) -> status code 204 for 'successful update'
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await db.Users
                .FirstOrDefaultAsync(x => String.Equals(x.EmailAddress, user.EmailAddress));

            if (result == null)
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();

                UserDto dto = new UserDto
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Surname = user.Surname,
                    EmailAddress = user.EmailAddress,
                    ProfilePicture = user.ProfilePictureString
                };

                return CreatedAtRoute("DefaultApi", new { id = dto.UserId }, dto);
            }

            dynamic response = new ExpandoObject();
            response.message = "Email address already exist";

            return Content<object>(HttpStatusCode.BadRequest, response);

            
        }

        // DELETE: api/Users/5
        //[ResponseType(typeof(User))]
        //public async Task<IHttpActionResult> DeleteUser(long id)
        //{
        //    User user = await db.Users.FirstOrDefaultAsync(x => x.UserId == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Users.Remove(user);
        //    await db.SaveChangesAsync();

        //    return Ok(user);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(long id)
        {
            return db.Users.Count(e => e.UserId == id) > 0;
        }
    }

    
}