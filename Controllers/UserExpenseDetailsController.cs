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
    public class UserExpenseDetailsController : ApiController
    {
        private ExpenseManagerEntities db = new ExpenseManagerEntities();

        // GET: api/UserExpenseDetails
        public IQueryable<User_Expense_Details> GetUser_Expense_Details()
        {
            return db.User_Expense_Details;
        }

        // GET: api/UserExpenseDetails/5
        [ResponseType(typeof(User_Expense_Details))]
        public IHttpActionResult GetUser_Expense_Details(string id)
        {
            User_Expense_Details user_Expense_Details = db.User_Expense_Details.Find(id);
            if (user_Expense_Details == null)
            {
                return NotFound();
            }

            return Ok(user_Expense_Details);
        }

        // PUT: api/UserExpenseDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser_Expense_Details(string id, User_Expense_Details user_Expense_Details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user_Expense_Details.UserId)
            {
                return BadRequest();
            }

            db.Entry(user_Expense_Details).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_Expense_DetailsExists(id))
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

        // POST: api/UserExpenseDetails
        [ResponseType(typeof(User_Expense_Details))]
        public IHttpActionResult PostUser_Expense_Details(User_Expense_Details user_Expense_Details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.User_Expense_Details.Add(user_Expense_Details);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (User_Expense_DetailsExists(user_Expense_Details.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = user_Expense_Details.UserId }, user_Expense_Details);
        }

        // DELETE: api/UserExpenseDetails/5
        [ResponseType(typeof(User_Expense_Details))]
        public IHttpActionResult DeleteUser_Expense_Details(string id)
        {
            User_Expense_Details user_Expense_Details = db.User_Expense_Details.Find(id);
            if (user_Expense_Details == null)
            {
                return NotFound();
            }

            db.User_Expense_Details.Remove(user_Expense_Details);
            db.SaveChanges();

            return Ok(user_Expense_Details);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool User_Expense_DetailsExists(string id)
        {
            return db.User_Expense_Details.Count(e => e.UserId == id) > 0;
        }
    }
}