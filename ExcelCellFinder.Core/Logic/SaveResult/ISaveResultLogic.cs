using ExcelCellFinder.Core.Result.Interface;

namespace ExcelCellFinder.Core.Logic.SaveResult
{
    public interface ISaveResultLogic
    {
        void SaveResult(IResult result, FileInfo saveTo);
    }
}
