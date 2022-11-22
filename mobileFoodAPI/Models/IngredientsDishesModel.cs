using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mobileFoodAPI.Models
{
    public class IngredientsDishesModel
    {
        public IngredientsDishesModel(IngredientsDishes ingredientsDishes)
        {
            Code_IngredientsDishes = ingredientsDishes.Code_IngredientsDishes;
            Code_Dish = ingredientsDishes.Code_Dish;
            Code_Ingredient = ingredientsDishes.Code_Ingredient;
            Count_IngredientsDishes = ingredientsDishes.Count_IngredientsDishes;
        }

        public int Code_IngredientsDishes { get; set; }
        public int Code_Dish { get; set; }
        public int Code_Ingredient { get; set; }
        public int Count_IngredientsDishes { get; set; }
    }
}