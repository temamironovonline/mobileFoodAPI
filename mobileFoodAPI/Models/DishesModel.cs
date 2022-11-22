using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mobileFoodAPI.Models
{
    public class DishesModel
    {

        public DishesModel(Dishes dishes)
        {
            Code_Dish = dishes.Code_Dish;
            Name_Dish = dishes.Name_Dish;
            Description_Dish = dishes.Description_Dish;
            Cooking_Time_Dish = dishes.Cooking_Time_Dish;
            Recipe_Dish = dishes.Recipe_Dish;
            Portion_Dish = dishes.Portion_Dish;
            Image_Dish = dishes.Image_Dish;
        }

        public int Code_Dish { get; set; }
        public string Name_Dish { get; set; }
        public string Description_Dish { get; set; }
        public string Cooking_Time_Dish { get; set; }
        public string Recipe_Dish { get; set; }
        public int Portion_Dish { get; set; }
        public byte[] Image_Dish { get; set; }
    }
}