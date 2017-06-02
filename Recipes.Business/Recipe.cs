using System;
using System.Collections.Generic;

namespace Recipes.Business
{
    public class Recipe
    {
        public Recipe()
        {
            RecipeId = Guid.NewGuid();
            Ingredients = new List<string>();
            Steps = new List<string>();
        }

        public Guid RecipeId { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Steps { get; set; }

    }
}
