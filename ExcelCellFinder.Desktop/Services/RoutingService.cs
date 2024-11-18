using ExcelCellFinder.Desktop.ViewModels;
using ExcelCellFinder.Desktop.ViewModels.Pages;

namespace ExcelCellFinder.Desktop.Services
{
    public class RoutingService
    {
        private static RoutingService? _instance;
        public static RoutingService Instance
        {
            get { return _instance ?? throw new InvalidOperationException("Not Initialized."); }
        }

        public static void Initialize(MainWindowViewModel vm)
        {
            _instance = new RoutingService(vm);
        }

        public MainWindowViewModel Main { get; private set; }

        private RoutingService(MainWindowViewModel vm)
        {
            Main = vm;
        }

        public void MoveTo(PageViewModelBase pageVM)
        {
            Main.CurrentPage = pageVM;
        }
    }
}
