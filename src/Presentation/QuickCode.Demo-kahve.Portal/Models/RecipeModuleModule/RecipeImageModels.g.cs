using QuickCode.Demo-kahve.Common.Nswag.Clients.RecipeModuleModuleApi.Contracts; using  System ;  using  Microsoft . AspNetCore . Mvc . Rendering ;  using  System . Collections . Generic ;  using  System . Linq ;  using  QuickCode . Demo
-kahve.Portal.Helpers;
namespace QuickCode.Demo - kahve . Portal . Models . RecipeModuleModule {
    public class RecipeImageData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public RecipeImageDto SelectedItem { get; set; }
        public List<RecipeImageDto> List { get; set; }
    }

    public static partial class RecipeImageExtensions
    {
        public static string GetKey(this RecipeImageDto dto)
        {
            return $"{dto.Id}";
        }

        public static List<string> GetImageColumnNames(this RecipeImageDto dto) => new()
        {
            "ImageUrl"
        };
    }
}