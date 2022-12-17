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
    public class DishTypesController : ApiController
    {
        private FoodEntities db = new FoodEntities();

        // GET: api/DishTypes
        [ResponseType(typeof(List<DishTypes>))]
        public IHttpActionResult GetDishTypes()
        {
            return Ok(db.DishTypes.ToList().ConvertAll(x => new TypeDishesModel(x)));
        }

        // GET: api/DishTypes/5
        [ResponseType(typeof(DishTypes))]
        public IHttpActionResult GetDishTypes(int id)
        {
            DishTypes dishTypes = db.DishTypes.Find(id);
            if (dishTypes == null)
            {
                return NotFound();
            }

            return Ok(dishTypes);
        }

        // PUT: api/DishTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDishTypes(int id, DishTypes dishTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dishTypes.Code_DishType)
            {
                return BadRequest();
            }

            db.Entry(dishTypes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishTypesExists(id))
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

        // POST: api/DishTypes
        [ResponseType(typeof(DishTypes))]
        public IHttpActionResult PostDishTypes(DishTypes dishTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DishTypes.Add(dishTypes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dishTypes.Code_DishType }, dishTypes);
        }

        // DELETE: api/DishTypes/5
        [ResponseType(typeof(DishTypes))]
        public IHttpActionResult DeleteDishTypes(int id)
        {
            DishTypes dishTypes = db.DishTypes.Find(id);
            if (dishTypes == null)
            {
                return NotFound();
            }

            db.DishTypes.Remove(dishTypes);
            db.SaveChanges();

            return Ok(dishTypes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DishTypesExists(int id)
        {
            return db.DishTypes.Count(e => e.Code_DishType == id) > 0;
        }
    }
}