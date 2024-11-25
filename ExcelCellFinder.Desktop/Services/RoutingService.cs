using ExcelCellFinder.Desktop.ViewModels;
using ExcelCellFinder.Desktop.ViewModels.Pages;

namespace ExcelCellFinder.Desktop.Services
{
    /// <summary>
    /// ルーティングサービス
    /// </summary>
    public class RoutingService
    {
        private static RoutingService? _instance;

        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        public static RoutingService Instance
        {
            get { return _instance ?? throw new InvalidOperationException("Not Initialized."); }
        }

        /// <summary>
        /// シングルトンインスタンスを初期化
        /// </summary>
        /// <param name="vm">メインウインドウViewModel</param>
        public static void Initialize(MainWindowViewModel vm)
        {
            _instance = new RoutingService(vm);
        }

        public MainWindowViewModel Main { get; private set; }

        private RoutingService(MainWindowViewModel vm)
        {
            Main = vm;
        }

        /// <summary>
        /// 指定したページに遷移する
        /// </summary>
        /// <param name="pageVM">遷移先ページのViewModel</param>
        public void MoveTo(PageViewModelBase pageVM)
        {
            Main.CurrentPage = pageVM;
        }
    }
}
