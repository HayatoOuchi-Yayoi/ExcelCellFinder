using ExcelCellFinder.Core.Result.Interface;

namespace ExcelCellFinder.Core.Logic.SaveResult
{
    /// <summary>
    /// 検索結果保存ロジックインタフェース
    /// </summary>
    public interface ISaveResultLogic
    {
        /// <summary>
        /// 検索結果を保存する
        /// </summary>
        /// <param name="result">検索結果</param>
        /// <param name="saveTo">保存先ファイル</param>
        void SaveResult(IResult result, FileInfo saveTo);
    }
}
