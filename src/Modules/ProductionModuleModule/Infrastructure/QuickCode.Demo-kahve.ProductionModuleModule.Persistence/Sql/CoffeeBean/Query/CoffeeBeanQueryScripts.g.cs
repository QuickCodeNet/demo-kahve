namespace QuickCode.Demo - kahve . ProductionModuleModule . Persistence . Sql ; 
    public static partial class SqlScripts
    {
        public static partial class CoffeeBean
        {
            public static class Query
            {
                private const string _prefix = "ProductionModuleModule.CoffeeBean.Query";
                private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
                public static string GetByOrigin => ResourceKey("GetByOrigin.g.sql");
                public static string GetByBatchId => ResourceKey("GetByBatchId.g.sql");
                public static string GetTotalWeight => ResourceKey("GetTotalWeight.g.sql");
                public static string GetRoastingProcessesForCoffeeBeans => ResourceKey("GetRoastingProcessesForCoffeeBeans.g.sql");
                public static string GetRoastingProcessesForCoffeeBeansDetails => ResourceKey("GetRoastingProcessesForCoffeeBeansDetails.g.sql");
            }
        }
    }