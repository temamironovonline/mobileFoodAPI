
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
    public class DishesController : ApiController
    {
        private FoodEntities db = new FoodEntities();

        // GET: api/Dishes
        [ResponseType(typeof(List<DishesModel>))]
        public IHttpActionResult GetDishes()
        {
            return Ok(db.Dishes.ToList().ConvertAll(x => new DishesModel(x)));
        }

        // GET: api/Dishes/5
        [ResponseType(typeof(DishesModel))]
        public IHttpActionResult GetDishes(int id)
        {
            List<DishesModel> dishes = db.Dishes.ToList().ConvertAll(x => new DishesModel(x));

            DishesModel dish = dishes.FirstOrDefault(x => x.Code_Dish == id);
            if (dish == null)
            {
                return NotFound();
            }

            return Ok(dish);
        }

        // PUT: api/Dishes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDishes(int id, Dishes dishes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dishes.Code_Dish)
            {
                return BadRequest();
            }

            db.Entry(dishes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishesExists(id))
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

        // POST: api/Dishes
        [ResponseType(typeof(Dishes))]
        public IHttpActionResult PostDishes(Dishes dishes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dishes.Add(dishes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dishes.Code_Dish }, dishes);
        }

        // DELETE: api/Dishes/5
        [ResponseType(typeof(Dishes))]
        public IHttpActionResult DeleteDishes(int id)
        {
            Dishes dishes = db.Dishes.Find(id);
            if (dishes == null)
            {
                return NotFound();
            }

            db.Dishes.Remove(dishes);
            db.SaveChanges();

            return Ok(dishes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DishesExists(int id)
        {
            return db.Dishes.Count(e => e.Code_Dish == id) > 0;
        }
    }
}