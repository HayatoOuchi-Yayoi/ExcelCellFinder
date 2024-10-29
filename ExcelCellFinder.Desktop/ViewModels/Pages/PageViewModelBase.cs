using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ExcelCellFinder.Desktop.ViewModels.Pages
{
    public abstract partial class PageViewModelBase : ObservableObject
    {
        [ObservableProperty]
        private string _pageTitle = "";
    }
}
