namespace ExcelCellFinder.Desktop.Services.CollectFileList
{
    internal class CollectFileListServiceFactory
    {
        public static ICollectFileListService GetService()
        {
            return new CollectFileListService();
        }
    }
}
