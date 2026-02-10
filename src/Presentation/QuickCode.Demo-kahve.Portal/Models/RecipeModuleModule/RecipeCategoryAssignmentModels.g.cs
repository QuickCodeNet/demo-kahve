using QuickCode.Demo-kahve.Common.Nswag.Clients.RecipeModuleModuleApi.Contracts; using  System ;  using  Microsoft . AspNetCore . Mvc . Rendering ;  using  System . Collections . Generic ;  using  System . Linq ;  using  QuickCode . Demo
-kahve.Portal.Helpers;
namespace QuickCode.Demo - kahve . Portal . Models . RecipeModuleModule {
    public class RecipeCategoryAssignmentData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public RecipeCategoryAssignmentDto SelectedItem { get; set; }
        public List<RecipeCategoryAssignmentDto> List { get; set; }
    }

    public static partial class RecipeCategoryAssignmentExtensions
    {
        public static string GetKey(this RecipeCategoryAssignmentDto dto)
        {
            return $"{dto.Id}";
        }
    }
}