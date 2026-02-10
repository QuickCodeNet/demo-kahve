using QuickCode.Demo-kahve.Common.Nswag.Clients.RecipeModuleModuleApi.Contracts; using  System ;  using  Microsoft . AspNetCore . Mvc . Rendering ;  using  System . Collections . Generic ;  using  System . Linq ;  using  QuickCode . Demo
-kahve.Portal.Helpers;
namespace QuickCode.Demo - kahve . Portal . Models . RecipeModuleModule {
    public class RecipeCategoryData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public RecipeCategoryDto SelectedItem { get; set; }
        public List<RecipeCategoryDto> List { get; set; }
    }

    public static partial class RecipeCategoryExtensions
    {
        public static string GetKey(this RecipeCategoryDto dto)
        {
            return $"{dto.Id}";
        }
    }
}