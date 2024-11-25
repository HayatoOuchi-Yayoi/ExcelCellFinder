using CommunityToolkit.Mvvm.ComponentModel;
using ExcelCellFinder.Desktop.ViewModels.Pages;

namespace ExcelCellFinder.Desktop.ViewModels
{
    /// <summary>
    /// メインウィンドウのViewModel
    /// </summary>
    public partial class MainWindowViewModel : ObservableObject
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowViewModel()
        {
            _currentPage = new SetupConditionPageViewModel();
        }

        /// <summary>
        /// 現在の表示ページ
        /// </summary>
        [ObservableProperty]
        private PageViewModelBase _currentPage;
    }
}
