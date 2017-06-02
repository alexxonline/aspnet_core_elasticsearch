using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Business
{
    public interface IRecipeRepository
    {
        void AddRecipe(Recipe recipe);
        Recipe GetRecipe(Guid recipeId);
        List<Recipe> ListRecipes(string ingredient);

    }
}
