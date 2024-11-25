using ClosedXML.Excel;
using ExcelCellFinder.Core.Result.Interface;

namespace ExcelCellFinder.Core.Result
{
    /// <summary>
    /// 検索結果セル情報クラス
    /// </summary>
    internal class FoundCell : IFoundCell
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="cell">セル情報（ClosedXML）</param>
        internal FoundCell(IXLCell cell)
        {
            SheetName = cell.Worksheet.Name;
            RowNumber = cell.Address.RowNumber;
            ColumnNumber = cell.Address.ColumnNumber;
            Column = cell.Address.ColumnLetter;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="cell">セル情報（ClosedXML）</param>
        /// <param name="e">例外情報</param>
        internal FoundCell(IXLCell cell, Exception e)
        {
            SheetName = cell.Worksheet.Name;
            RowNumber = cell.Address.RowNumber;
            ColumnNumber = cell.Address.ColumnNumber;
            Column = cell.Address.ColumnLetter;
            ErrorMessage = e.Message;
        }

        public string SheetName { get; set; }
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public string Column { get; set; }
        public string ErrorMessage { get; set; } = "";

        /// <summary>
        /// 文字列生成
        /// </summary>
        /// <returns>"シート名!A1"形式の文字列</returns>
        public override string ToString()
        {
            return $"{SheetName}!{Column}{RowNumber}";
        }

        /// <summary>
        /// セル名取得
        /// </summary>
        /// <returns>"A1"形式のセル文字列</returns>
        public string GetCellName()
        {
            return $"{Column}{RowNumber}";
        }
    }
}
