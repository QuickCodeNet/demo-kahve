namespace QuickCode.Demo - kahve . RecipeModuleModule . Persistence . Sql ; 
    public static partial class SqlScripts
    {
        public static partial class RecipeCategoryAssignment
        {
            public static class Query
            {
                private const string _prefix = "RecipeModuleModule.RecipeCategoryAssignment.Query";
                private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
                public static string GetByRecipeId => ResourceKey("GetByRecipeId.g.sql");
                public static string GetByCategoryId => ResourceKey("GetByCategoryId.g.sql");
            }
        }
    }