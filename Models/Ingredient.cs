using System;
using System.Collections.Generic;

#nullable disable

namespace SharpeningTheSaw.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public long IngredientId { get; set; }
        public string IngredientName { get; set; }
        public long? IngredientClassId { get; set; }
        public long? MeasureAmountId { get; set; }

        public virtual IngredientClass IngredientClass { get; set; }
        public virtual Measurement MeasureAmount { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
