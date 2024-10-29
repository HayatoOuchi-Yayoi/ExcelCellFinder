namespace ExcelCellFinder.Desktop.Services.FindCell
{
    internal class FindCellServiceFactory
    {
        public static IFindCellService GetService()
        {
            return new FindCellService();
        }
    }
}
