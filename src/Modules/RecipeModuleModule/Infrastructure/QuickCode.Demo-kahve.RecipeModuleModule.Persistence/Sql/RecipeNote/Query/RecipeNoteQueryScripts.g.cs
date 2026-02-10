namespace QuickCode.Demo - kahve . RecipeModuleModule . Persistence . Sql ; 
    public static partial class SqlScripts
    {
        public static partial class RecipeNote
        {
            public static class Query
            {
                private const string _prefix = "RecipeModuleModule.RecipeNote.Query";
                private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
                public static string GetByRecipeId => ResourceKey("GetByRecipeId.g.sql");
            }
        }
    }