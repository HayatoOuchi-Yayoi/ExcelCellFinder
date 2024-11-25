namespace ExcelCellFinder.Desktop.Services.CollectFileList
{
    /// <summary>
    /// 検索対象ファイルリスト収集サービスのファクトリクラス
    /// </summary>
    internal class CollectFileListServiceFactory
    {
        /// <summary>
        /// 検索対象ファイルリスト収集サービスを取得する
        /// </summary>
        /// <returns>検索対象ファイルリスト収集サービス</returns>
        public static ICollectFileListService GetService()
        {
            return new CollectFileListService();
        }
    }
}
