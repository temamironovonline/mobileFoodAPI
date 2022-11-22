using mobileFoodAPI.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace mobileFoodAPI.Controllers
{
    public class IngredientsDishesController : ApiController
    {
        private FoodEntities db = new FoodEntities();

        // GET: api/IngredientsDishes
        [ResponseType(typeof(List<IngredientsDishesModel>))]
        public IHttpActionResult GetIngredientsDishes()
        {
            return Ok(db.IngredientsDishes.ToList().ConvertAll(x => new IngredientsDishesModel(x)));
        }

        // GET: api/IngredientsDishes/5
        [ResponseType(typeof(IngredientsDishes))]
        public IHttpActionResult GetIngredientsDishes(int id)
        {
            IngredientsDishes ingredientsDishes = db.IngredientsDishes.Find(id);
            if (ingredientsDishes == null)
            {
                return NotFound();
            }

            return Ok(ingredientsDishes);
        }

        // PUT: api/IngredientsDishes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIngredientsDishes(int id, IngredientsDishes ingredientsDishes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingredientsDishes.Code_IngredientsDishes)
            {
                return BadRequest();
            }

            db.Entry(ingredientsDishes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientsDishesExists(id))
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

        // POST: api/IngredientsDishes
        [ResponseType(typeof(IngredientsDishes))]
        public IHttpActionResult PostIngredientsDishes(IngredientsDishes ingredientsDishes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IngredientsDishes.Add(ingredientsDishes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ingredientsDishes.Code_IngredientsDishes }, ingredientsDishes);
        }

        // DELETE: api/IngredientsDishes/5
        [ResponseType(typeof(IngredientsDishes))]
        public IHttpActionResult DeleteIngredientsDishes(int id)
        {
            IngredientsDishes ingredientsDishes = db.IngredientsDishes.Find(id);
            if (ingredientsDishes == null)
            {
                return NotFound();
            }

            db.IngredientsDishes.Remove(ingredientsDishes);
            db.SaveChanges();

            return Ok(ingredientsDishes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IngredientsDishesExists(int id)
        {
            return db.IngredientsDishes.Count(e => e.Code_IngredientsDishes == id) > 0;
        }
    }
}