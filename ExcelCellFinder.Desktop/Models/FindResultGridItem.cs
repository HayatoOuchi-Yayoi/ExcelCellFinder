namespace ExcelCellFinder.Desktop.Models
{
    /// <summary>
    /// 検索結果一覧グリッドアイテム
    /// </summary>
    public partial class FindResultGridItem
    {
        public string ファイル { get; set; } = "";
        public string シート名 { get; set; } = "";
        public string セル { get; set; } = "";
        public string エラーメッセージ { get; set; } = "";
    }
}
