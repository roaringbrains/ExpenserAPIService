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
    public class IncomeSourceController : ApiController
    {
        private ExpenseManagerEntities db = new ExpenseManagerEntities();

        // GET: api/IncomeSource
        public IQueryable<Income_Source> GetIncome_Source()
        {
            return db.Income_Source;
        }

        // GET: api/IncomeSource/5
        [ResponseType(typeof(Income_Source))]
        public IHttpActionResult GetIncome_Source(string id)
        {
            Income_Source income_Source = db.Income_Source.Find(id);
            if (income_Source == null)
            {
                return NotFound();
            }

            return Ok(income_Source);
        }

        // PUT: api/IncomeSource/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIncome_Source(string id, Income_Source income_Source)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != income_Source.UserId)
            {
                return BadRequest();
            }

            db.Entry(income_Source).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Income_SourceExists(id))
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

        // POST: api/IncomeSource
        [ResponseType(typeof(Income_Source))]
        public IHttpActionResult PostIncome_Source(Income_Source income_Source)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Income_Source.Add(income_Source);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Income_SourceExists(income_Source.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = income_Source.UserId }, income_Source);
        }

        // DELETE: api/IncomeSource/5
        [ResponseType(typeof(Income_Source))]
        public IHttpActionResult DeleteIncome_Source(string id)
        {
            Income_Source income_Source = db.Income_Source.Find(id);
            if (income_Source == null)
            {
                return NotFound();
            }

            db.Income_Source.Remove(income_Source);
            db.SaveChanges();

            return Ok(income_Source);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Income_SourceExists(string id)
        {
            return db.Income_Source.Count(e => e.UserId == id) > 0;
        }
    }
}