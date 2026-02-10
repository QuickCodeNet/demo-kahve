using QuickCode.Demo-kahve.Common.Nswag.Clients.RecipeModuleModuleApi.Contracts; using  System ;  using  Microsoft . AspNetCore . Mvc . Rendering ;  using  System . Collections . Generic ;  using  System . Linq ;  using  QuickCode . Demo
-kahve.Portal.Helpers;
namespace QuickCode.Demo - kahve . Portal . Models . RecipeModuleModule {
    public class RecipeIngredientData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public RecipeIngredientDto SelectedItem { get; set; }
        public List<RecipeIngredientDto> List { get; set; }
    }

    public static partial class RecipeIngredientExtensions
    {
        public static string GetKey(this RecipeIngredientDto dto)
        {
            return $"{dto.Id}";
        }
    }
}