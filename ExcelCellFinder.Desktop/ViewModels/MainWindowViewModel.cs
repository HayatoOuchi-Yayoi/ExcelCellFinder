using CommunityToolkit.Mvvm.ComponentModel;
using ExcelCellFinder.Desktop.ViewModels.Pages;

namespace ExcelCellFinder.Desktop.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel()
        {
            _currentPage = new SetupConditionPageViewModel();
        }

        [ObservableProperty]
        private PageViewModelBase _currentPage;
    }
}
