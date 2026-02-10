namespace QuickCode.Demo - kahve . RecipeModuleModule . Persistence . Sql ; 
    public static partial class SqlScripts
    {
        public static partial class Recipe
        {
            public static class Query
            {
                private const string _prefix = "RecipeModuleModule.Recipe.Query";
                private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
                public static string GetActive => ResourceKey("GetActive.g.sql");
                public static string SearchByName => ResourceKey("SearchByName.g.sql");
                public static string GetRecipeIngredientsForRecipes => ResourceKey("GetRecipeIngredientsForRecipes.g.sql");
                public static string GetRecipeIngredientsForRecipesDetails => ResourceKey("GetRecipeIngredientsForRecipesDetails.g.sql");
                public static string GetRecipeEquipmentsForRecipes => ResourceKey("GetRecipeEquipmentsForRecipes.g.sql");
                public static string GetRecipeEquipmentsForRecipesDetails => ResourceKey("GetRecipeEquipmentsForRecipesDetails.g.sql");
                public static string GetRecipeNotesForRecipes => ResourceKey("GetRecipeNotesForRecipes.g.sql");
                public static string GetRecipeNotesForRecipesDetails => ResourceKey("GetRecipeNotesForRecipesDetails.g.sql");
                public static string GetRecipeImagesForRecipes => ResourceKey("GetRecipeImagesForRecipes.g.sql");
                public static string GetRecipeImagesForRecipesDetails => ResourceKey("GetRecipeImagesForRecipesDetails.g.sql");
                public static string GetRecipeCategoryAssignmentsForRecipes => ResourceKey("GetRecipeCategoryAssignmentsForRecipes.g.sql");
                public static string GetRecipeCategoryAssignmentsForRecipesDetails => ResourceKey("GetRecipeCategoryAssignmentsForRecipesDetails.g.sql");
            }
        }
    }