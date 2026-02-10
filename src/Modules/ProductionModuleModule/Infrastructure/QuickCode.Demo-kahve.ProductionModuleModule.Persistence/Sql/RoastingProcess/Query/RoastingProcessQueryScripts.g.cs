namespace QuickCode.Demo - kahve . ProductionModuleModule . Persistence . Sql ; 
    public static partial class SqlScripts
    {
        public static partial class RoastingProcess
        {
            public static class Query
            {
                private const string _prefix = "ProductionModuleModule.RoastingProcess.Query";
                private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
                public static string GetByBeanBatchId => ResourceKey("GetByBeanBatchId.g.sql");
                public static string GetByStatus => ResourceKey("GetByStatus.g.sql");
                public static string GetGrindingProcessesForRoastingProcesses => ResourceKey("GetGrindingProcessesForRoastingProcesses.g.sql");
                public static string GetGrindingProcessesForRoastingProcessesDetails => ResourceKey("GetGrindingProcessesForRoastingProcessesDetails.g.sql");
            }
        }
    }