namespace ExcelCellFinder.Desktop.Services.SaveResult
{
    /// <summary>
    /// セル検索結果保存サービスのファクトリクラス
    /// </summary>
    internal class SaveResultServiceFactory
    {
        /// <summary>
        /// セル検索結果保存サービスを取得する
        /// </summary>
        /// <returns>セル検索結果保存サービス</returns>
        public static ISaveResultService GetService(string saveFilePath)
        {
            return new SaveResultExcelService { SaveFilePath = saveFilePath };
        }
    }
}
