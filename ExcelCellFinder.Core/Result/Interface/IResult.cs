using ExcelCellFinder.Core.Options.Interface;

namespace ExcelCellFinder.Core.Result.Interface
{
    public interface IResult
    {
        IFindCellOptions ExecutedOptions { get; protected set; }

        bool IsError { get; protected set; }

        IList<IResultFile> ProcessedFiles { get; protected set; }

        IResult Merge(IResult result);
    }
}
