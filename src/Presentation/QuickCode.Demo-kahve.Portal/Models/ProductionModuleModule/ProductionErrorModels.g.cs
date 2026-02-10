using QuickCode.Demo-kahve.Common.Nswag.Clients.ProductionModuleModuleApi.Contracts; using  System ;  using  Microsoft . AspNetCore . Mvc . Rendering ;  using  System . Collections . Generic ;  using  System . Linq ;  using  QuickCode . Demo
-kahve.Portal.Helpers;
namespace QuickCode.Demo - kahve . Portal . Models . ProductionModuleModule {
    public class ProductionErrorData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public ProductionErrorDto SelectedItem { get; set; }
        public List<ProductionErrorDto> List { get; set; }
    }

    public static partial class ProductionErrorExtensions
    {
        public static string GetKey(this ProductionErrorDto dto)
        {
            return $"{dto.Id}";
        }
    }
}