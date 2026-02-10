namespace QuickCode.Demo - kahve . ProductionModuleModule . Persistence . Sql ; 
    public static partial class SqlScripts
    {
        public static partial class GrindingProcess
        {
            public static class Command
            {
                private const string _prefix = "ProductionModuleModule.GrindingProcess.Command";
                private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
                public static string UpdateStatus => ResourceKey("UpdateStatus.g.sql");
            }
        }
    }