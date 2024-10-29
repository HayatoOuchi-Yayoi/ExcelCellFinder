namespace ExcelCellFinder.Desktop.Services.SaveResult
{
    internal class SaveResultServiceFactory
    {
        public static ISaveResultService GetService(string saveFilePath)
        {
            return new SaveResultExcelService { SaveFilePath = saveFilePath };
        }
    }
}
