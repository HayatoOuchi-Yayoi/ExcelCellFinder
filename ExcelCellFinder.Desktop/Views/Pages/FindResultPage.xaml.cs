using ExcelCellFinder.Desktop.Services;
using ExcelCellFinder.Desktop.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            this.DataContext = (FindResultPageViewModel) RoutingService.Instance.Main.CurrentPage;
        }
    }
}
