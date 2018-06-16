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

namespace HLSB.Controllers
{
    public class BinaryObjectsController : ApiController
    {
        private HlsbContext db = new HlsbContext();

        // GET: api/BinaryObjects
        public IQueryable<BinaryObject> GetBinaryObjects()
        {
            return db.BinaryObjects;
        }

        // GET: api/BinaryObjects/5
        [ResponseType(typeof(BinaryObject))]
        public async Task<IHttpActionResult> GetBinaryObject(int id)
        {
            BinaryObject binaryObject = await db.BinaryObjects.FirstOrDefaultAsync(x => x.Id == id);
            if (binaryObject == null)
            {
                return NotFound();
            }

            return Ok(binaryObject);
        }

        // PUT: api/BinaryObjects/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBinaryObject(int id, BinaryObject binaryObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != binaryObject.Id)
            {
                return BadRequest();
            }

            db.Entry(binaryObject).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BinaryObjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BinaryObjects
        [ResponseType(typeof(BinaryObject))]
        public async Task<IHttpActionResult> PostBinaryObject(BinaryObject binaryObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BinaryObjects.Add(binaryObject);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = binaryObject.Id }, binaryObject);
        }

        // DELETE: api/BinaryObjects/5
        [ResponseType(typeof(BinaryObject))]
        public async Task<IHttpActionResult> DeleteBinaryObject(int id)
        {
            BinaryObject binaryObject = await db.BinaryObjects.FirstOrDefaultAsync(x => x.Id == id);
            if (binaryObject == null)
            {
                return NotFound();
            }

            db.BinaryObjects.Remove(binaryObject);
            await db.SaveChangesAsync();

            return Ok(binaryObject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BinaryObjectExists(int id)
        {
            return db.BinaryObjects.Count(e => e.Id == id) > 0;
        }
    }
}