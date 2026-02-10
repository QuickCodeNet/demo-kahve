namespace QuickCode.Demo - kahve . RecipeModuleModule . Persistence . Sql ; 
    public static partial class SqlScripts
    {
        public static partial class RecipeCategory
        {
            public static class Query
            {
                private const string _prefix = "RecipeModuleModule.RecipeCategory.Query";
                private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
                public static string GetActive => ResourceKey("GetActive.g.sql");
                public static string GetRecipeCategoryAssignmentsForRecipeCategories => ResourceKey("GetRecipeCategoryAssignmentsForRecipeCategories.g.sql");
                public static string GetRecipeCategoryAssignmentsForRecipeCategoriesDetails => ResourceKey("GetRecipeCategoryAssignmentsForRecipeCategoriesDetails.g.sql");
            }
        }
    }