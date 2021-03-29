using System;
using System.Collections.Generic;

#nullable disable

namespace SharpeningTheSaw.Models
{
    public partial class Measurement
    {
        public Measurement()
        {
            Ingredients = new HashSet<Ingredient>();
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public long MeasureAmountId { get; set; }
        public string MeasurementDescription { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
