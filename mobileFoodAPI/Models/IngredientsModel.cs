using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mobileFoodAPI.Models
{
    public class IngredientsModel
    {

        public IngredientsModel(Ingredients ingredients)
        {
            Code_Ingredient = ingredients.Code_Ingregient;
            Name_Ingredient = ingredients.Name_Ingredient;
        }

        public int Code_Ingredient { get; set; }
        public string Name_Ingredient { get; set; }


    }
}