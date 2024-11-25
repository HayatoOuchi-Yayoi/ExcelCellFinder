using ExcelCellFinder.Core.Options.Interface;
using ExcelCellFinder.Core.Result.Interface;

namespace ExcelCellFinder.Core.Result
{
    /// <summary>
    /// セル検索結果クラス
    /// </summary>
    internal class FindCellResult : IResult
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="executedOption">実行した検索オプション</param>
        /// <param name="isError">エラーフラグ</param>
        internal FindCellResult(IFindCellOptions executedOption, bool isError)
        {
            ExecutedOptions = executedOption;
            IsError = isError;
            ProcessedFiles = [];
        }

        public IFindCellOptions ExecutedOptions { get; set; }
        public bool IsError { get; set; }
        public IList<IResultFile> ProcessedFiles { get; set; }

        public IResult Merge(IResult anotherResult)
        {
            return new FindCellResult(ExecutedOptions, IsError)
            {
                IsError = IsError || anotherResult.IsError,
                ProcessedFiles = ProcessedFiles.Concat(anotherResult.ProcessedFiles).ToList()
            };
        }
    }
}
