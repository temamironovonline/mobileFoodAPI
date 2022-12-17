using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mobileFoodAPI.Models
{
    public class TypeDishesModel
    {

        public TypeDishesModel(DishTypes dishType)
        {
            Code_DishType = dishType.Code_DishType;
            Name_DishType = dishType.Name_DishType;
        }

        public int Code_DishType { get; set; }
        public string Name_DishType { get; set; }
    }
}