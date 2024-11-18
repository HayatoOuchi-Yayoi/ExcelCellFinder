using ExcelCellFinder.Desktop.Services;
using ExcelCellFinder.Desktop.ViewModels;
using System.Windows;

namespace ExcelCellFinder.Desktop.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RoutingService.Initialize((MainWindowViewModel)this.DataContext);
        }
    }
}
