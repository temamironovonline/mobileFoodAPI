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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FoodEntities : DbContext
    {
        public FoodEntities()
            : base("name=FoodEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Dishes> Dishes { get; set; }
        public virtual DbSet<DishTypes> DishTypes { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<IngredientsDishes> IngredientsDishes { get; set; }
        public virtual DbSet<NationalCuisine> NationalCuisine { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
