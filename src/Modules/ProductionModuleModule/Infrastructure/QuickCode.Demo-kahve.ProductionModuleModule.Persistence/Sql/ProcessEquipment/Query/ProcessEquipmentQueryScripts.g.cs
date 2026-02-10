namespace QuickCode.Demo - kahve . ProductionModuleModule . Persistence . Sql ; 
    public static partial class SqlScripts
    {
        public static partial class ProcessEquipment
        {
            public static class Query
            {
                private const string _prefix = "ProductionModuleModule.ProcessEquipment.Query";
                private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
                public static string GetActive => ResourceKey("GetActive.g.sql");
            }
        }
    }