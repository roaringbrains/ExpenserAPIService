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
    public class UserCredentialController : ApiController
    {
        private ExpenseManagerEntities db = new ExpenseManagerEntities();

        // GET: api/UserCredential
        public IQueryable<User_Credential> GetUser_Credential()
        {
            return db.User_Credential;
        }

        // GET: api/UserCredential/5
        [ResponseType(typeof(User_Credential))]
        public IHttpActionResult GetUser_Credential(string id)
        {
            User_Credential user_Credential = db.User_Credential.Find(id);
            if (user_Credential == null)
            {
                return NotFound();
            }

            return Ok(user_Credential);
        }

        // PUT: api/UserCredential/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser_Credential(string id, User_Credential user_Credential)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user_Credential.UserId)
            {
                return BadRequest();
            }

            db.Entry(user_Credential).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_CredentialExists(id))
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

        // POST: api/UserCredential
        [ResponseType(typeof(User_Credential))]
        public IHttpActionResult PostUser_Credential(User_Credential user_Credential)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.User_Credential.Add(user_Credential);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (User_CredentialExists(user_Credential.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = user_Credential.UserId }, user_Credential);
        }

        // DELETE: api/UserCredential/5
        [ResponseType(typeof(User_Credential))]
        public IHttpActionResult DeleteUser_Credential(string id)
        {
            User_Credential user_Credential = db.User_Credential.Find(id);
            if (user_Credential == null)
            {
                return NotFound();
            }

            db.User_Credential.Remove(user_Credential);
            db.SaveChanges();

            return Ok(user_Credential);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool User_CredentialExists(string id)
        {
            return db.User_Credential.Count(e => e.UserId == id) > 0;
        }
    }
}