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
    public class ExpenseCategoryController : ApiController
    {
        private ExpenseManagerEntities db = new ExpenseManagerEntities();

        // GET: api/ExpenseCategory
        public IQueryable<Expense_Category> GetExpense_Category()
        {
            return db.Expense_Category;
        }

        // GET: api/ExpenseCategory/5
        [ResponseType(typeof(Expense_Category))]
        public IHttpActionResult GetExpense_Category(decimal id,decimal subId)
        {
            Expense_Category expense_Category = db.Expense_Category.Where(
                m => m.ExpenseCategory == id & m.ExpenseSubCategory == subId).FirstOrDefault();
            if (expense_Category == null)
            {
                return NotFound();
            }

            return Ok(expense_Category);
        }

        // PUT: api/ExpenseCategory/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExpense_Category(decimal id, Expense_Category expense_Category)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != expense_Category.ExpenseCategory)
            {
                return BadRequest();
            }

            db.Entry(expense_Category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Expense_CategoryExists(id))
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

        // POST: api/ExpenseCategory
        [ResponseType(typeof(Expense_Category))]
        public IHttpActionResult PostExpense_Category(Expense_Category expense_Category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Expense_Category.Add(expense_Category);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Expense_CategoryExists(expense_Category.ExpenseCategory))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = expense_Category.ExpenseCategory }, expense_Category);
        }

        // DELETE: api/ExpenseCategory/5
        [ResponseType(typeof(Expense_Category))]
        public IHttpActionResult DeleteExpense_Category(decimal id)
        {
            Expense_Category expense_Category = db.Expense_Category.Find(id);
            if (expense_Category == null)
            {
                return NotFound();
            }

            db.Expense_Category.Remove(expense_Category);
            db.SaveChanges();

            return Ok(expense_Category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Expense_CategoryExists(decimal id)
        {
            return db.Expense_Category.Count(e => e.ExpenseCategory == id) > 0;
        }
    }
}