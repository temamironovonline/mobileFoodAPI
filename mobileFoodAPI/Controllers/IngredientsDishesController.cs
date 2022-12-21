using mobileFoodAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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


        [Route("api/IngredientsDishes/getFullRecipe")]
        [HttpGet] // There are HttpGet, HttpPost, HttpPut, HttpDelete.
        public IHttpActionResult getFullRecipe(string nameIngredients, string countIngredient)
        {
            nameIngredients = nameIngredients.Trim();
            countIngredient = countIngredient.Trim();
            string[] nameIngredientSplit = nameIngredients.Split(' ');

            string[] countIngredientSplit = countIngredient.Split(' ');

            int[] countIngredientDigit = new int[countIngredientSplit.Count()];

            for (int i = 0; i < countIngredientDigit.Count(); i++)
            {
                countIngredientDigit[i] = Convert.ToInt32(countIngredientSplit[i]);
            }

            List<DishesModel> dishesList = db.Dishes.ToList().ConvertAll(x => new DishesModel(x));

            List<DishesModel> fullRecipeDish = new List<DishesModel>();

            for (int i = 0; i < dishesList.Count(); i++)
            {
                DishesModel dish = dishesList[i];
                List<IngredientsDishesModel> ingredientsDish = db.IngredientsDishes.Where(x => x.Code_Dish == dish.Code_Dish).ToList().ConvertAll(x => new IngredientsDishesModel(x));

                int counterIngredients = 0;
                for (int j = 0; j < nameIngredientSplit.Count(); j++)
                {
                    string ingredient = nameIngredientSplit[j];
                    List<IngredientsModel> ingredientsList = db.Ingredients.ToList().ConvertAll(x => new IngredientsModel(x));
                    IngredientsModel ing = ingredientsList.FirstOrDefault(x => x.Name_Ingredient == ingredient);
                    int countIngredientCurrent = countIngredientDigit[j];
                    IngredientsDishesModel ingredients = ingredientsDish.FirstOrDefault(x => x.Code_Ingredient == ing.Code_Ingregient && countIngredientCurrent >= x.Count_IngredientsDishes);
                    if (ingredients != null)
                    {
                        counterIngredients++;
                    }
                    ingredients = null;
                }

                if (counterIngredients >= ingredientsDish.Count())
                {
                    fullRecipeDish.Add(dish);
                }

            }

            for (int i = 0; i < dishesList.Count(); i++)
            {

                DishesModel dish = dishesList[i];
                bool sameDish = false;
                for (int check = 0; check < fullRecipeDish.Count(); check++)
                {
                    if (fullRecipeDish[check] == dish) sameDish = true;
                }

                if (sameDish)
                {
                    sameDish = false;
                    continue;
                }

                List<IngredientsDishesModel> ingredientsDish = db.IngredientsDishes.Where(x => x.Code_Dish == dish.Code_Dish).ToList().ConvertAll(x => new IngredientsDishesModel(x));

                for (int j = 0; j < nameIngredientSplit.Count(); j++)
                {
                    string ingredient = nameIngredientSplit[j];
                    List<IngredientsModel> ingredientsList = db.Ingredients.ToList().ConvertAll(x => new IngredientsModel(x));
                    IngredientsModel ing = ingredientsList.FirstOrDefault(x => x.Name_Ingredient == ingredient);
                    int countIngredientCurrent = countIngredientDigit[j];
                    IngredientsDishesModel ingredients = ingredientsDish.FirstOrDefault(x => x.Code_Ingredient == ing.Code_Ingregient && countIngredientCurrent >= x.Count_IngredientsDishes);

                    if (ingredients != null)
                    {
                        fullRecipeDish.Add(dish);
                    }

                }


            }

            return Ok(fullRecipeDish);
        }

        

        // GET: api/IngredientsDishes/5
        [ResponseType(typeof(IngredientsDishesModel))]
        public IHttpActionResult GetIngredientsDishes(int id)
        {
            List<IngredientsDishesModel> ingredientsDishes = db.IngredientsDishes.ToList().ConvertAll(x => new IngredientsDishesModel(x));
            IngredientsDishesModel ingredientsDish = ingredientsDishes.FirstOrDefault(x => x.Code_IngredientsDishes == id);
            if (ingredientsDish == null)
            {
                return NotFound();
            }

            return Ok(ingredientsDish);
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