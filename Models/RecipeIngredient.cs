using System;
using System.Collections.Generic;

#nullable disable

namespace SharpeningTheSaw.Models
{
    public partial class RecipeIngredient
    {
        public long RecipeId { get; set; }
        public long RecipeSeqNo { get; set; }
        public long? IngredientId { get; set; }
        public long? MeasureAmountId { get; set; }
        public double? Amount { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Measurement MeasureAmount { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
