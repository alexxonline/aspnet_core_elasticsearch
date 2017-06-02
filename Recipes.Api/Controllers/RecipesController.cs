using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipes.Business;

namespace Recipes.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Recipes")]
    public class RecipesController : Controller
    {
        private readonly IRecipeRepository RecipeRepository;
        public RecipesController(IRecipeRepository recipeRepository)
        {
            if(recipeRepository == null)
            {
                throw new ArgumentNullException("recipeRepository");
            }

            this.RecipeRepository = recipeRepository;
        }

        [HttpGet]
        public List<Recipe> Get(string ingredient = "") // El valor por defecto es vacío pero si paso algo, filtra
        {
            return RecipeRepository.ListRecipes(ingredient);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Recipe recipe)
        {
            RecipeRepository.AddRecipe(recipe);
            return Ok();
        }

        [HttpGet("{id}")]
        public Recipe Get(Guid id)
        {
            return RecipeRepository.GetRecipe(id);
        }
    }
}