namespace ExcelCellFinder.Core.Result.Interface
{
    /// <summary>
    /// 検索結果セル情報インターフェース
    /// </summary>
    public interface IFoundCell
    {
        /// <summary>
        /// シート名
        /// </summary>
        string SheetName { get; protected set; }
        /// <summary>
        /// 行番号
        /// </summary>
        int RowNumber { get; protected set; }
        /// <summary>
        /// カラム番号
        /// </summary>
        int ColumnNumber { get; protected set; }
        /// <summary>
        /// カラム名
        /// </summary>
        string Column { get; protected set; }
        /// <summary>
        /// エラーメッセージ
        /// </summary>
        string ErrorMessage { get; protected set; }

        string ToString();

        string GetCellName();
    }
}
