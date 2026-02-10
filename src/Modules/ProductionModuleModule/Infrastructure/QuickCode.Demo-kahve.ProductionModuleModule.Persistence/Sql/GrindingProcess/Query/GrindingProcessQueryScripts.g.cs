namespace QuickCode.Demo - kahve . ProductionModuleModule . Persistence . Sql ; 
    public static partial class SqlScripts
    {
        public static partial class GrindingProcess
        {
            public static class Query
            {
                private const string _prefix = "ProductionModuleModule.GrindingProcess.Query";
                private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
                public static string GetByRoastingProcessId => ResourceKey("GetByRoastingProcessId.g.sql");
                public static string GetByStatus => ResourceKey("GetByStatus.g.sql");
                public static string GetPackagingProcessesForGrindingProcesses => ResourceKey("GetPackagingProcessesForGrindingProcesses.g.sql");
                public static string GetPackagingProcessesForGrindingProcessesDetails => ResourceKey("GetPackagingProcessesForGrindingProcessesDetails.g.sql");
            }
        }
    }