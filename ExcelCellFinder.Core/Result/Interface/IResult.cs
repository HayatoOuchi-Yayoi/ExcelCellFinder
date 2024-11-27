using ExcelCellFinder.Core.Options.Interface;

namespace ExcelCellFinder.Core.Result.Interface
{
    /// <summary>
    /// セル検索結果インターフェース
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// 検索オプション
        /// </summary>
        IFindCellOptions ExecutedOptions { get; protected set; }

        /// <summary>
        /// エラーフラグ
        /// </summary>
        bool IsError { get; protected set; }

        /// <summary>
        /// 検索を行ったファイル情報リスト
        /// </summary>
        IList<IResultFile> ProcessedFiles { get; protected set; }

        /// <summary>
        /// 検索結果マージ処理
        /// </summary>
        /// <param name="result">マージ対象検索結果インスタンス</param>
        /// <returns>マージ後検索結果</returns>
        IResult Merge(IResult result);
    }
}
