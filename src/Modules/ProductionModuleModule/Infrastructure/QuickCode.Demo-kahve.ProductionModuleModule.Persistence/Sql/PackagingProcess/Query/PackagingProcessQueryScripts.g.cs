namespace QuickCode.Demo - kahve . ProductionModuleModule . Persistence . Sql ; 
    public static partial class SqlScripts
    {
        public static partial class PackagingProcess
        {
            public static class Query
            {
                private const string _prefix = "ProductionModuleModule.PackagingProcess.Query";
                private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
                public static string GetByGrindingProcessId => ResourceKey("GetByGrindingProcessId.g.sql");
                public static string GetByStatus => ResourceKey("GetByStatus.g.sql");
            }
        }
    }