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
using mobileFoodAPI;
using mobileFoodAPI.Models;

namespace mobileFoodAPI.Controllers
{
    public class NationalCuisinesController : ApiController
    {
        private FoodEntities db = new FoodEntities();

        // GET: api/NationalCuisines
        [ResponseType (typeof (List<NationalCuisine>))]
        public IHttpActionResult GetNationalCuisine()
        {
            return Ok(db.NationalCuisine.ToList().ConvertAll(x => new CuisineModel(x)));
        }

        // GET: api/NationalCuisines/5
        [ResponseType(typeof(NationalCuisine))]
        public IHttpActionResult GetNationalCuisine(int id)
        {
            NationalCuisine nationalCuisine = db.NationalCuisine.Find(id);
            if (nationalCuisine == null)
            {
                return NotFound();
            }

            return Ok(nationalCuisine);
        }

        // PUT: api/NationalCuisines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNationalCuisine(int id, NationalCuisine nationalCuisine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nationalCuisine.Code_NationalCuisine)
            {
                return BadRequest();
            }

            db.Entry(nationalCuisine).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NationalCuisineExists(id))
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

        // POST: api/NationalCuisines
        [ResponseType(typeof(NationalCuisine))]
        public IHttpActionResult PostNationalCuisine(NationalCuisine nationalCuisine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NationalCuisine.Add(nationalCuisine);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nationalCuisine.Code_NationalCuisine }, nationalCuisine);
        }

        // DELETE: api/NationalCuisines/5
        [ResponseType(typeof(NationalCuisine))]
        public IHttpActionResult DeleteNationalCuisine(int id)
        {
            NationalCuisine nationalCuisine = db.NationalCuisine.Find(id);
            if (nationalCuisine == null)
            {
                return NotFound();
            }

            db.NationalCuisine.Remove(nationalCuisine);
            db.SaveChanges();

            return Ok(nationalCuisine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NationalCuisineExists(int id)
        {
            return db.NationalCuisine.Count(e => e.Code_NationalCuisine == id) > 0;
        }
    }
}