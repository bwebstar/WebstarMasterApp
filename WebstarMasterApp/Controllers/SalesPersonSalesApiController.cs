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
using WebstarMasterApp.Models;

namespace WebstarMasterApp.Controllers
{
    public class SalesPersonSalesApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/SalesPersonSalesApi
        public IQueryable<SalesPersonSales> GetSalesPersonSales()
        {
            return db.SalesPersonSales;
        }

        // GET: api/SalesPersonSalesApi/5
        [ResponseType(typeof(SalesPersonSales))]
        public IHttpActionResult GetSalesPersonSales(int id)
        {
            SalesPersonSales salesPersonSales = db.SalesPersonSales.Find(id);
            if (salesPersonSales == null)
            {
                return NotFound();
            }

            return Ok(salesPersonSales);
        }

        // PUT: api/SalesPersonSalesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSalesPersonSales(int id, SalesPersonSales salesPersonSales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salesPersonSales.Id)
            {
                return BadRequest();
            }

            db.Entry(salesPersonSales).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesPersonSalesExists(id))
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

        // POST: api/SalesPersonSalesApi
        [ResponseType(typeof(SalesPersonSales))]
        public IHttpActionResult PostSalesPersonSales(SalesPersonSales salesPersonSales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SalesPersonSales.Add(salesPersonSales);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = salesPersonSales.Id }, salesPersonSales);
        }

        // DELETE: api/SalesPersonSalesApi/5
        [ResponseType(typeof(SalesPersonSales))]
        public IHttpActionResult DeleteSalesPersonSales(int id)
        {
            SalesPersonSales salesPersonSales = db.SalesPersonSales.Find(id);
            if (salesPersonSales == null)
            {
                return NotFound();
            }

            db.SalesPersonSales.Remove(salesPersonSales);
            db.SaveChanges();

            return Ok(salesPersonSales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalesPersonSalesExists(int id)
        {
            return db.SalesPersonSales.Count(e => e.Id == id) > 0;
        }
    }
}