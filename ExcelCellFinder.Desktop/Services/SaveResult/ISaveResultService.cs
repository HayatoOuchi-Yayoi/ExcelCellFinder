using ExcelCellFinder.Core.Result.Interface;

namespace ExcelCellFinder.Desktop.Services.SaveResult
{
    internal interface ISaveResultService
    {
        string? SaveFilePath { get; set; }

        void SaveResult(IResult saveData);
    }
}
