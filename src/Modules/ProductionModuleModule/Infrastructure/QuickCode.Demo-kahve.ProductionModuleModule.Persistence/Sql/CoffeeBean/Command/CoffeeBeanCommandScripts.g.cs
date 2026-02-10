namespace QuickCode.Demo - kahve . ProductionModuleModule . Persistence . Sql ; 
    public static partial class SqlScripts
    {
        public static partial class CoffeeBean
        {
            public static class Command
            {
                private const string _prefix = "ProductionModuleModule.CoffeeBean.Command";
                private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
                public static string UpdateWeight => ResourceKey("UpdateWeight.g.sql");
            }
        }
    }