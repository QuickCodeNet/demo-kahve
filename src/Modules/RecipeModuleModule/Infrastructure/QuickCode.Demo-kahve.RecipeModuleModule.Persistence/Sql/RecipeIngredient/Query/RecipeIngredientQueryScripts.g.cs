namespace QuickCode.Demo - kahve . RecipeModuleModule . Persistence . Sql ; 
    public static partial class SqlScripts
    {
        public static partial class RecipeIngredient
        {
            public static class Query
            {
                private const string _prefix = "RecipeModuleModule.RecipeIngredient.Query";
                private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
                public static string GetByRecipeId => ResourceKey("GetByRecipeId.g.sql");
            }
        }
    }