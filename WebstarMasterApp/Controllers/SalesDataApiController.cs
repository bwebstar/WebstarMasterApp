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
    public class SalesDataApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/SalesDataApi
        public IQueryable<SalesData> GetSalesData()
        {
            return db.SalesData;
        }

        // GET: api/SalesDataApi/5
        [ResponseType(typeof(SalesData))]
        public IHttpActionResult GetSalesData(int id)
        {
            SalesData salesData = db.SalesData.Find(id);
            if (salesData == null)
            {
                return NotFound();
            }

            return Ok(salesData);
        }

        // PUT: api/SalesDataApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSalesData(int id, SalesData salesData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salesData.Id)
            {
                return BadRequest();
            }

            db.Entry(salesData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesDataExists(id))
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

        // POST: api/SalesDataApi
        [ResponseType(typeof(SalesData))]
        public IHttpActionResult PostSalesData(SalesData salesData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SalesData.Add(salesData);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = salesData.Id }, salesData);
        }

        // DELETE: api/SalesDataApi/5
        [ResponseType(typeof(SalesData))]
        public IHttpActionResult DeleteSalesData(int id)
        {
            SalesData salesData = db.SalesData.Find(id);
            if (salesData == null)
            {
                return NotFound();
            }

            db.SalesData.Remove(salesData);
            db.SaveChanges();

            return Ok(salesData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalesDataExists(int id)
        {
            return db.SalesData.Count(e => e.Id == id) > 0;
        }
    }
}