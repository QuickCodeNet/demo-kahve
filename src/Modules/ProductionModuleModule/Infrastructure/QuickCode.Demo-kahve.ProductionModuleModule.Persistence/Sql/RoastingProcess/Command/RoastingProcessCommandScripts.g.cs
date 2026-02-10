namespace QuickCode.Demo - kahve . ProductionModuleModule . Persistence . Sql ; 
    public static partial class SqlScripts
    {
        public static partial class RoastingProcess
        {
            public static class Command
            {
                private const string _prefix = "ProductionModuleModule.RoastingProcess.Command";
                private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
                public static string UpdateStatus => ResourceKey("UpdateStatus.g.sql");
            }
        }
    }