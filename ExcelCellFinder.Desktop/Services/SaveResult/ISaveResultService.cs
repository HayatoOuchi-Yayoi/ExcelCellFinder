using ExcelCellFinder.Core.Result.Interface;

namespace ExcelCellFinder.Desktop.Services.SaveResult
{
    /// <summary>
    /// セル検索結果保存インターフェース
    /// </summary>
    internal interface ISaveResultService
    {
        string? SaveFilePath { get; set; }

        /// <summary>
        /// セル検索結果を保存する
        /// </summary>
        /// <param name="saveData">保存データ</param>
        void SaveResult(IResult saveData);
    }
}
