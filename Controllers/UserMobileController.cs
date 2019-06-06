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
using ExpenserAPIService.Models;

namespace ExpenserAPIService.Controllers
{
    public class UserMobileController : ApiController
    {
        private ExpenseManagerEntities db = new ExpenseManagerEntities();

        // GET: api/UserMobile
        public IQueryable<User_Mobile> GetUser_Mobile()
        {
            return db.User_Mobile;
        }

        // GET: api/UserMobile/5
        [ResponseType(typeof(User_Mobile))]
        public IHttpActionResult GetUser_Mobile(string id)
        {
            User_Mobile user_Mobile = db.User_Mobile.Find(id);
            if (user_Mobile == null)
            {
                return NotFound();
            }

            return Ok(user_Mobile);
        }

        // PUT: api/UserMobile/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser_Mobile(string id, User_Mobile user_Mobile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user_Mobile.UserId)
            {
                return BadRequest();
            }

            db.Entry(user_Mobile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_MobileExists(id))
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

        // POST: api/UserMobile
        [ResponseType(typeof(User_Mobile))]
        public IHttpActionResult PostUser_Mobile(User_Mobile user_Mobile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.User_Mobile.Add(user_Mobile);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (User_MobileExists(user_Mobile.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = user_Mobile.UserId }, user_Mobile);
        }

        // DELETE: api/UserMobile/5
        [ResponseType(typeof(User_Mobile))]
        public IHttpActionResult DeleteUser_Mobile(string id)
        {
            User_Mobile user_Mobile = db.User_Mobile.Find(id);
            if (user_Mobile == null)
            {
                return NotFound();
            }

            db.User_Mobile.Remove(user_Mobile);
            db.SaveChanges();

            return Ok(user_Mobile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool User_MobileExists(string id)
        {
            return db.User_Mobile.Count(e => e.UserId == id) > 0;
        }
    }
}