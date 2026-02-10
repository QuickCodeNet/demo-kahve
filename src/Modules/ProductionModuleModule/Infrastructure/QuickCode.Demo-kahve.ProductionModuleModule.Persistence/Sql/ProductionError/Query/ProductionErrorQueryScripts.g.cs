namespace QuickCode.Demo - kahve . ProductionModuleModule . Persistence . Sql ; 
    public static partial class SqlScripts
    {
        public static partial class ProductionError
        {
            public static class Query
            {
                private const string _prefix = "ProductionModuleModule.ProductionError.Query";
                private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
                public static string GetByProcessId => ResourceKey("GetByProcessId.g.sql");
            }
        }
    }