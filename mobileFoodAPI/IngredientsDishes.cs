//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mobileFoodAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class IngredientsDishes
    {
        public int Code_IngredientsDishes { get; set; }
        public int Code_Dish { get; set; }
        public int Code_Ingredient { get; set; }
        public int Count_IngredientsDishes { get; set; }
    
        public virtual Dishes Dishes { get; set; }
        public virtual Ingredients Ingredients { get; set; }
    }
}
