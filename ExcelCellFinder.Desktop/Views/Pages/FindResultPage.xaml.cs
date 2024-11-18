using ExcelCellFinder.Desktop.Services;
using ExcelCellFinder.Desktop.ViewModels.Pages;
using System.Windows.Controls;

namespace ExcelCellFinder.Desktop.Views.Pages
{
    /// <summary>
    /// FindResultPage.xaml の相互作用ロジック
    /// </summary>
    public partial class FindResultPage : UserControl
    {
        public FindResultPage()
        {
            InitializeComponent();
            this.DataContext = (FindResultPageViewModel)RoutingService.Instance.Main.CurrentPage;
        }
    }
}
