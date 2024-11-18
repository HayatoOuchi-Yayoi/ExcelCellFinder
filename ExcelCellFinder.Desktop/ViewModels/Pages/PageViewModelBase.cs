using CommunityToolkit.Mvvm.ComponentModel;

namespace ExcelCellFinder.Desktop.ViewModels.Pages
{
    public abstract partial class PageViewModelBase : ObservableObject
    {
        [ObservableProperty]
        private string _pageTitle = "";
    }
}
