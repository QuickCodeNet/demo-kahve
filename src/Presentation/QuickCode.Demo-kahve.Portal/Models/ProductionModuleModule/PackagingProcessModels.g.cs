using QuickCode.Demo-kahve.Common.Nswag.Clients.ProductionModuleModuleApi.Contracts; using  System ;  using  Microsoft . AspNetCore . Mvc . Rendering ;  using  System . Collections . Generic ;  using  System . Linq ;  using  QuickCode . Demo
-kahve.Portal.Helpers;
namespace QuickCode.Demo - kahve . Portal . Models . ProductionModuleModule {
    public class PackagingProcessData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public PackagingProcessDto SelectedItem { get; set; }
        public List<PackagingProcessDto> List { get; set; }
    }

    public static partial class PackagingProcessExtensions
    {
        public static string GetKey(this PackagingProcessDto dto)
        {
            return $"{dto.Id}";
        }
    }
}