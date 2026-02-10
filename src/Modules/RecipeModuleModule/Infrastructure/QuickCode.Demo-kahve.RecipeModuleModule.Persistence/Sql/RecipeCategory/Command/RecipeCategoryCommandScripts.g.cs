namespace QuickCode.Demo - kahve . RecipeModuleModule . Persistence . Sql ; 
    public static partial class SqlScripts
    {
        public static partial class RecipeCategory
        {
            public static class Command
            {
                private const string _prefix = "RecipeModuleModule.RecipeCategory.Command";
                private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
                public static string Deactivate => ResourceKey("Deactivate.g.sql");
            }
        }
    }