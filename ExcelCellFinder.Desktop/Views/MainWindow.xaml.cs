using ExcelCellFinder.Desktop.Services;
using ExcelCellFinder.Desktop.ViewModels;
using System.Windows;

namespace ExcelCellFinder.Desktop.Views
{
    /// <summary>
    /// メインウィンドウのコードビハインド
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            RoutingService.Initialize((MainWindowViewModel)this.DataContext);
        }
    }
}
