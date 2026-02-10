using QuickCode.Demo-kahve.Common.Nswag.Clients.RecipeModuleModuleApi.Contracts; using  System ;  using  Microsoft . AspNetCore . Mvc . Rendering ;  using  System . Collections . Generic ;  using  System . Linq ;  using  QuickCode . Demo
-kahve.Portal.Helpers;
namespace QuickCode.Demo - kahve . Portal . Models . RecipeModuleModule {
    public class RecipeNoteData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public RecipeNoteDto SelectedItem { get; set; }
        public List<RecipeNoteDto> List { get; set; }
    }

    public static partial class RecipeNoteExtensions
    {
        public static string GetKey(this RecipeNoteDto dto)
        {
            return $"{dto.Id}";
        }
    }
}