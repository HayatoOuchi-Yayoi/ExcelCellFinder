using ExcelCellFinder.Desktop.Services;
using ExcelCellFinder.Desktop.ViewModels.Pages;
using System.Windows.Controls;

namespace ExcelCellFinder.Desktop.Views.Pages
{
    /// <summary>
    /// 検索結果画面のコードビハインド
    /// </summary>
    public partial class FindResultPage : UserControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FindResultPage()
        {
            InitializeComponent();

            // ページ遷移前後のバインドデータを復元するため、
            // ルーティングサービスからVMインスタンスを取得してDataContextに設定
            this.DataContext = (FindResultPageViewModel)RoutingService.Instance.Main.CurrentPage;
        }
    }
}
