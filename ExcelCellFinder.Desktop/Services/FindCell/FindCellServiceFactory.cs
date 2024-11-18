namespace ExcelCellFinder.Desktop.Services.FindCell
{
    /// <summary>
    /// セル検索サービスのファクトリクラス
    /// </summary>
    internal class FindCellServiceFactory
    {
        /// <summary>
        /// セル検索サービスを取得する
        /// </summary>
        /// <returns>セル検索サービス</returns>
        public static IFindCellService GetService()
        {
            return new FindCellService();
        }
    }
}
