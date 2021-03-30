using Microsoft.AspNetCore.Mvc;
using SharpeningTheSaw.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpeningTheSaw.Components
{
    public class MealTypeViewComponent : ViewComponent
    {
        private RecipesContext _context;
        public MealTypeViewComponent(RecipesContext txt)
        {
            _context = txt;
        }

        public IViewComponentResult Invoke()
        {
            return View(_context.RecipeClasses.Distinct().OrderBy(x => x));
        }
    }
}
