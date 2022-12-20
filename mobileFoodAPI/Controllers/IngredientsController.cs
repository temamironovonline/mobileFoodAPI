using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using mobileFoodAPI.Models;

namespace mobileFoodAPI.Controllers
{
    public class IngredientsController : ApiController
    {
        private FoodEntities db = new FoodEntities();

        // GET: api/Ingredients
        [ResponseType(typeof(List<Ingredients>))]
        public IHttpActionResult GetIngredients()
        {
            return Ok(db.Ingredients.ToList().ConvertAll(x => new IngredientsModel(x)));
        }

        // GET: api/Ingredients/5
        [ResponseType(typeof(Ingredients))]
        public IHttpActionResult GetIngredients(int id)
        {
            Ingredients ingredients = db.Ingredients.Find(id);
            if (ingredients == null)
            {
                return NotFound();
            }

            return Ok(ingredients);
        }

        // PUT: api/Ingredients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIngredients(int id, Ingredients ingredients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingredients.Code_Ingregient)
            {
                return BadRequest();
            }

            db.Entry(ingredients).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientsExists(id))
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

        // POST: api/Ingredients
        [ResponseType(typeof(Ingredients))]
        public IHttpActionResult PostIngredients(Ingredients ingredients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ingredients.Add(ingredients);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ingredients.Code_Ingregient }, ingredients);
        }

        // DELETE: api/Ingredients/5
        [ResponseType(typeof(Ingredients))]
        public IHttpActionResult DeleteIngredients(int id)
        {
            Ingredients ingredients = db.Ingredients.Find(id);
            if (ingredients == null)
            {
                return NotFound();
            }

            db.Ingredients.Remove(ingredients);
            db.SaveChanges();

            return Ok(ingredients);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IngredientsExists(int id)
        {
            return db.Ingredients.Count(e => e.Code_Ingregient == id) > 0;
        }
    }
}