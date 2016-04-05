using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebServiceDemo;

namespace WebServiceDemo.Controllers
{
    public class GuestlistsController : ApiController
    {
        private ViewContext db = new ViewContext();

        // GET: api/Guestlists
        public IQueryable<Guestlist> GetGuestlists()
        {
            return db.Guestlists;
        }

        // GET: api/Guestlists/5
        [ResponseType(typeof(Guestlist))]
        public IHttpActionResult GetGuestlist(string id)
        {
            Guestlist guestlist = db.Guestlists.Find(id);
            if (guestlist == null)
            {
                return NotFound();
            }

            return Ok(guestlist);
        }

        // PUT: api/Guestlists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGuestlist(string id, Guestlist guestlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != guestlist.HotelName)
            {
                return BadRequest();
            }

            db.Entry(guestlist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestlistExists(id))
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

        // POST: api/Guestlists
        [ResponseType(typeof(Guestlist))]
        public IHttpActionResult PostGuestlist(Guestlist guestlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Guestlists.Add(guestlist);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GuestlistExists(guestlist.HotelName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = guestlist.HotelName }, guestlist);
        }

        // DELETE: api/Guestlists/5
        [ResponseType(typeof(Guestlist))]
        public IHttpActionResult DeleteGuestlist(string id)
        {
            Guestlist guestlist = db.Guestlists.Find(id);
            if (guestlist == null)
            {
                return NotFound();
            }

            db.Guestlists.Remove(guestlist);
            db.SaveChanges();

            return Ok(guestlist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GuestlistExists(string id)
        {
            return db.Guestlists.Count(e => e.HotelName == id) > 0;
        }
    }
}