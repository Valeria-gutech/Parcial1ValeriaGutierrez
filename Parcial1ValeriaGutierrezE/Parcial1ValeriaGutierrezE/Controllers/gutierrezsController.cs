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
using Parcial1ValeriaGutierrezE.Models;

namespace Parcial1ValeriaGutierrezE.Controllers
{
    public class gutierrezsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/gutierrezs
        public IQueryable<gutierrez> Getgutierrezs()
        {
            return db.gutierrezs;
        }

        // GET: api/gutierrezs/5
        [ResponseType(typeof(gutierrez))]
        public IHttpActionResult Getgutierrez(int id)
        {
            gutierrez gutierrez = db.gutierrezs.Find(id);
            if (gutierrez == null)
            {
                return NotFound();
            }

            return Ok(gutierrez);
        }

        // PUT: api/gutierrezs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putgutierrez(int id, gutierrez gutierrez)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gutierrez.ProductID)
            {
                return BadRequest();
            }

            db.Entry(gutierrez).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gutierrezExists(id))
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

        // POST: api/gutierrezs
        [ResponseType(typeof(gutierrez))]
        public IHttpActionResult Postgutierrez(gutierrez gutierrez)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.gutierrezs.Add(gutierrez);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gutierrez.ProductID }, gutierrez);
        }

        // DELETE: api/gutierrezs/5
        [ResponseType(typeof(gutierrez))]
        public IHttpActionResult Deletegutierrez(int id)
        {
            gutierrez gutierrez = db.gutierrezs.Find(id);
            if (gutierrez == null)
            {
                return NotFound();
            }

            db.gutierrezs.Remove(gutierrez);
            db.SaveChanges();

            return Ok(gutierrez);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool gutierrezExists(int id)
        {
            return db.gutierrezs.Count(e => e.ProductID == id) > 0;
        }
    }
}