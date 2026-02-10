using QuickCode.Demo-kahve.Common.Nswag.Clients.ProductionModuleModuleApi.Contracts; using  System ;  using  Microsoft . AspNetCore . Mvc . Rendering ;  using  System . Collections . Generic ;  using  System . Linq ;  using  QuickCode . Demo
-kahve.Portal.Helpers;
namespace QuickCode.Demo - kahve . Portal . Models . ProductionModuleModule {
    public class GrindingProcessData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public GrindingProcessDto SelectedItem { get; set; }
        public List<GrindingProcessDto> List { get; set; }
    }

    public static partial class GrindingProcessExtensions
    {
        public static string GetKey(this GrindingProcessDto dto)
        {
            return $"{dto.Id}";
        }
    }
}