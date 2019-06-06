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
    public class IncomeCategoryController : ApiController
    {
        private ExpenseManagerEntities db = new ExpenseManagerEntities();

        // GET: api/IncomeCategory
        public IQueryable<Income_Category> GetIncome_Category()
        {
            return db.Income_Category;
        }

        // GET: api/IncomeCategory/5
        [ResponseType(typeof(Income_Category))]
        public IHttpActionResult GetIncome_Category(decimal id)
        {
            Income_Category income_Category = db.Income_Category.Find(id);
            if (income_Category == null)
            {
                return NotFound();
            }

            return Ok(income_Category);
        }

        // PUT: api/IncomeCategory/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIncome_Category(decimal id, Income_Category income_Category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != income_Category.IncomeCategoryId)
            {
                return BadRequest();
            }

            db.Entry(income_Category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Income_CategoryExists(id))
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

        // POST: api/IncomeCategory
        [ResponseType(typeof(Income_Category))]
        public IHttpActionResult PostIncome_Category(Income_Category income_Category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Income_Category.Add(income_Category);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Income_CategoryExists(income_Category.IncomeCategoryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = income_Category.IncomeCategoryId }, income_Category);
        }

        // DELETE: api/IncomeCategory/5
        [ResponseType(typeof(Income_Category))]
        public IHttpActionResult DeleteIncome_Category(decimal id)
        {
            Income_Category income_Category = db.Income_Category.Find(id);
            if (income_Category == null)
            {
                return NotFound();
            }

            db.Income_Category.Remove(income_Category);
            db.SaveChanges();

            return Ok(income_Category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Income_CategoryExists(decimal id)
        {
            return db.Income_Category.Count(e => e.IncomeCategoryId == id) > 0;
        }
    }
}