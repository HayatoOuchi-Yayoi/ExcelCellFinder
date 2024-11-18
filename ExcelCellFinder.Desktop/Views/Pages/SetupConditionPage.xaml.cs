using ExcelCellFinder.Desktop.Services;
using ExcelCellFinder.Desktop.ViewModels.Pages;
using System.Windows.Controls;

namespace ExcelCellFinder.Desktop.Views.Pages
{
    /// <summary>
    /// SetupConditionPage.xaml の相互作用ロジック
    /// </summary>
    public partial class SetupConditionPage : UserControl
    {
        public SetupConditionPage()
        {
            InitializeComponent();
            this.DataContext = (SetupConditionPageViewModel)RoutingService.Instance.Main.CurrentPage;
        }
    }
}
