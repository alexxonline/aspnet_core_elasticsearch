using Nest;
using Recipes.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// see  https://www.elastic.co/guide/en/elasticsearch/client/net-api/current/nest-getting-started.html

namespace Recipes.Data
{
    public class ElRecipeRepository : IRecipeRepository
    {
        public void AddRecipe(Recipe recipe)
        {
            var client = GetClient(); 
            var indexResponse = client.Index(recipe);
        }

        public Recipe GetRecipe(Guid recipeId)
        {
            var client = GetClient();

            var searchResponse = client.Search<Recipe>(s => s
                .From(0)
                .Size(10)
                .Query(q => q.Match
                        (m => m.Field(f => f.RecipeId)
                        .Query(recipeId.ToString())
                )));

            var recipe = searchResponse.Documents.ToList().FirstOrDefault();
            return recipe;
        }

        public List<Recipe> ListRecipes(string ingredient)
        {
            var client = GetClient();
            var searchResponse = client.Search<Recipe>(s => s
                .From(0)
                .Size(10)
                .Query(q => q.Match
                        (m => m.Field(f => f.Ingredients)
                        .Query(ingredient)
                )));

            var recipes = searchResponse.Documents.ToList();
            return recipes;
        }

        private ElasticClient GetClient()
        {
            var settings = new ConnectionSettings()
                .DefaultIndex("recipes"); // by default connects to localhost

            return  new ElasticClient(settings);
        }
    }
}
