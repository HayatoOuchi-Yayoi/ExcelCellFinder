namespace ExcelCellFinder.Core.Result.Interface
{
    /// <summary>
    /// 検索実行ファイル情報インターフェース
    /// </summary>
    public interface IResultFile
    {
        /// <summary>
        /// ファイル情報
        /// </summary>
        FileInfo FileInfo { get; protected set; }

        /// <summary>
        /// 検索結果セル情報リスト
        /// </summary>
        IList<IFoundCell> FoundCells { get; protected set; }
    }
}
