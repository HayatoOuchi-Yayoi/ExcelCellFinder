using ExcelCellFinder.Desktop.Services;
using ExcelCellFinder.Desktop.ViewModels.Pages;
using System.Windows.Controls;

namespace ExcelCellFinder.Desktop.Views.Pages
{
    /// <summary>
    /// 検索条件設定画面のコードビハインド
    /// </summary>
    public partial class SetupConditionPage : UserControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SetupConditionPage()
        {
            InitializeComponent();

            // ページ遷移前後のバインドデータを復元するため、
            // ルーティングサービスからVMインスタンスを取得してDataContextに設定
            this.DataContext = (SetupConditionPageViewModel)RoutingService.Instance.Main.CurrentPage;
        }
    }
}
