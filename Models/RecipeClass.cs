using System;
using System.Collections.Generic;

#nullable disable

namespace SharpeningTheSaw.Models
{
    public partial class RecipeClass
    {
        public RecipeClass()
        {
            Recipes = new HashSet<Recipe>();
        }

        public long RecipeClassId { get; set; }
        public string RecipeClassDescription { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
