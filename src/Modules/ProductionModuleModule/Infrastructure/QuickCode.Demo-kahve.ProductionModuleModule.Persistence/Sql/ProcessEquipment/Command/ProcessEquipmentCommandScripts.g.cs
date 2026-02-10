namespace QuickCode.Demo - kahve . ProductionModuleModule . Persistence . Sql ; 
    public static partial class SqlScripts
    {
        public static partial class ProcessEquipment
        {
            public static class Command
            {
                private const string _prefix = "ProductionModuleModule.ProcessEquipment.Command";
                private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
                public static string Deactivate => ResourceKey("Deactivate.g.sql");
            }
        }
    }