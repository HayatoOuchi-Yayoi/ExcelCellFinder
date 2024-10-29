using CommunityToolkit.Mvvm.ComponentModel;
using ExcelCellFinder.Desktop.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
