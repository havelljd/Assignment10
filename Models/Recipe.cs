using System;
using System.Collections.Generic;

#nullable disable

namespace SharpeningTheSaw.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public long RecipeId { get; set; }
        public string RecipeTitle { get; set; }
        public long? RecipeClassId { get; set; }
        public string Preparation { get; set; }
        public string Notes { get; set; }

        public virtual RecipeClass RecipeClass { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
