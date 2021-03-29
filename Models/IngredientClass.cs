using System;
using System.Collections.Generic;

#nullable disable

namespace SharpeningTheSaw.Models
{
    public partial class IngredientClass
    {
        public IngredientClass()
        {
            Ingredients = new HashSet<Ingredient>();
        }

        public long IngredientClassId { get; set; }
        public string IngredientClassDescription { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
