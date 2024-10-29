using ExcelCellFinder.Core.Options.Interface;
using ExcelCellFinder.Core.Result.Interface;

namespace ExcelCellFinder.Core.Result
{
    internal class FindCellResult : IResult
    {
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
