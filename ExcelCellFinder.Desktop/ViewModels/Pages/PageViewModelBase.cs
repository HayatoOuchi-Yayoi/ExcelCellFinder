using CommunityToolkit.Mvvm.ComponentModel;

namespace ExcelCellFinder.Desktop.ViewModels.Pages
{
    /// <summary>
    /// 画面ViewModelの基底クラス
    /// </summary>
    public abstract partial class PageViewModelBase : ObservableObject
    {
        /// <summary>
        /// 画面タイトル
        /// </summary>
        [ObservableProperty]
        private string _pageTitle = "";
    }
}
